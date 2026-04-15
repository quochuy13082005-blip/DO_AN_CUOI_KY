using System;
using System.Collections.Generic;
using System.Linq;

namespace DO_AN_CUOI_KY
{
    public class CitizenSeeder
    {

        static Random rnd = new Random();

        static string[] phonePrefixes = { "090", "091", "098", "032", "035", "038", "070", "077", "083", "085" };

        // ===== 63 TỈNH =====
        static Dictionary<string, string> provinceMap = new Dictionary<string, string>()
        {
            {"001","Hà Nội"},{"002","Hà Giang"},{"004","Cao Bằng"},{"006","Bắc Kạn"},
            {"008","Tuyên Quang"},{"010","Lào Cai"},{"011","Điện Biên"},{"012","Lai Châu"},
            {"014","Sơn La"},{"015","Yên Bái"},{"017","Hòa Bình"},{"019","Thái Nguyên"},
            {"020","Lạng Sơn"},{"022","Quảng Ninh"},{"024","Bắc Giang"},{"025","Phú Thọ"},
            {"026","Vĩnh Phúc"},{"027","Bắc Ninh"},{"030","Hải Dương"},{"031","Hải Phòng"},
            {"033","Hưng Yên"},{"034","Thái Bình"},{"035","Hà Nam"},{"036","Nam Định"},
            {"037","Ninh Bình"},{"038","Thanh Hóa"},{"040","Nghệ An"},{"042","Hà Tĩnh"},
            {"044","Quảng Bình"},{"045","Quảng Trị"},{"046","Thừa Thiên Huế"},{"048","Đà Nẵng"},
            {"049","Quảng Nam"},{"051","Quảng Ngãi"},{"052","Bình Định"},{"054","Phú Yên"},
            {"056","Khánh Hòa"},{"058","Ninh Thuận"},{"060","Bình Thuận"},{"062","Kon Tum"},
            {"064","Gia Lai"},{"066","Đắk Lắk"},{"067","Đắk Nông"},{"068","Lâm Đồng"},
            {"070","Bình Phước"},{"072","Tây Ninh"},{"074","Bình Dương"},{"075","Đồng Nai"},
            {"077","Bà Rịa - Vũng Tàu"},{"079","TP.HCM"},{"080","Long An"},{"082","Tiền Giang"},
            {"083","Bến Tre"},{"084","Trà Vinh"},{"086","Vĩnh Long"},{"087","Đồng Tháp"},
            {"089","An Giang"},{"091","Kiên Giang"},{"092","Cần Thơ"},{"093","Hậu Giang"},
            {"094","Sóc Trăng"},{"095","Bạc Liêu"},{"096","Cà Mau"}
        };

        static string[] GetProvinceCodes()
        {
            string[] code = new string[provinceMap.Count];
            int index = 0;
            foreach (string key in provinceMap.Keys)
            {
                code[index] = key;
                index++;
            }
            return code;
        }

        static string[] ho = {"Nguyễn", "Trần", "Lê", "Phạm", "Hoàng",
                               "Phan", "Vũ", "Võ", "Đặng", "Bùi",
                                "Đỗ", "Hồ", "Ngô", "Dương", "Lý",
                                 "Đinh", "Mai", "Tô", "Tạ", "Trịnh",
                                 "Châu", "Lương", "Hà", "Tăng", "Hứa"
                              };

        static string[] dem = {"Văn", "Thị", "Minh", "Đức", "Hữu",
                              "Quang", "Gia", "Thanh", "Công", "Thành",
                               "Ngọc", "Anh", "Trọng", "Khánh", "Bảo",
                                "Thiên", "Hoàng", "Tuấn", "Duy", "Phước",
                                "Xuân", "Thùy", "Kim", "Phương", "Diệu",
                                "Nhật", "Trung", "Hải"
                              };

        static string[] ten = {"An", "Bình", "Cường", "Dũng", "Huy",
                                "Nam", "Phúc", "Khoa", "Long", "Sơn",
                                "Tùng", "Hải", "Phong", "Vinh", "Khôi",
                                "Linh", "Trang", "Mai", "Hà", "Thảo",
                                "Nhi", "Vy", "Yến", "Lan", "Quỳnh",
                                "Minh", "Đạt", "Tuấn", "Kiệt", "Lộc",
                                "Phát", "Giang", "Trâm", "Uyên", "Chi"
                                };

        static string[] genders = { "Nam", "Nữ" };

        static string[] occupations = { "Sinh viên","Học sinh", "Kỹ sư","Bác sĩ","Giáo viên",
                                        "Công an","Bộ đội","Nhân viên văn phòng", "Kinh doanh",
                                        "Tài xế", "Công nhân","Luật sư","Lập trình viên", "Freelancer"
                                       };

        // ===== TRÁNH TRÙNG ID =====
        static HashSet<string> usedIDs = new HashSet<string>();

        // ===== TẠO CCCD =====
        public static string GenerateCitizenID(DateTime dob, string gender)
        {
            string[] provinceCodes = GetProvinceCodes();
            string province = provinceCodes[rnd.Next(provinceCodes.Length)];

            int genderCode;
            if (dob.Year >= 2000)
                genderCode = gender == "Nam" ? 2 : 3;
            else
                genderCode = gender == "Nam" ? 0 : 1;

            string year = (dob.Year % 100).ToString("D2");

            string id = " ";
            bool isDuplicate = true;
            while (isDuplicate)
            {
                string randomPart = rnd.Next(0, 999999).ToString("D6");
                id = province + genderCode + year + randomPart;
                if (!usedIDs.Contains(id))
                {
                    isDuplicate = false;
                }
            }
            usedIDs.Add(id);
            return id;
        }
        public static string GeneratePhoneNumber()
        {
            string prefix = phonePrefixes[rnd.Next(phonePrefixes.Length)];
            // Tạo 7 số ngẫu nhiên còn lại
            string suffix = rnd.Next(0, 10000000).ToString("D7");
            return prefix + suffix;
        }

        // ===== SEED =====
        public static void Seed(BinarySearchTree tree, int n = 1000)
        {
            //Tài khoản cố dịnh để test admin 
            Citizen admin = new Citizen();
            admin.CitizenID = "admin001";
            admin.FullName = "Nguyễn Văn An";
            admin.Password = "123";
            admin.Gender = "Nam";
            admin.DateOfBirth = new DateTime(2000, 1, 1);
            admin.Address = "Trung tâm quản lý";
            tree.Insert(admin);

            List<string> existingIDs = new List<string>();

            //Tài khoản cố dịnh để test user
            Citizen testUser = new Citizen();
            testUser.CitizenID = "001012000001";
            testUser.FullName = "Nguyễn Văn An";
            testUser.Password = "An@001";
            testUser.Gender = "Nam";
            testUser.DateOfBirth = new DateTime(2000, 1, 1);
            testUser.Address = provinceMap["001"];
            testUser.PhoneNumber = "0987654321";
            tree.Insert(testUser);

            List<Citizen> tempSample = new List<Citizen>();
            //Tạo ngẫu nhiên n công dân
            for (int i = 0; i < n; i++)
            {
                string gender = genders[rnd.Next(genders.Length)];

                DateTime dob = new DateTime(
                    rnd.Next(1970, 2010),
                    rnd.Next(1, 13),
                    rnd.Next(1, 28)
                );

                string id = GenerateCitizenID(dob, gender);

                string fullName =
                    ho[rnd.Next(ho.Length)] + " " +
                    dem[rnd.Next(dem.Length)] + " " +
                    ten[rnd.Next(ten.Length)];

                string provinceCode = id.Substring(0, 3);

                Citizen c = new Citizen();
                c.CitizenID = id;
                c.FullName = fullName;
                c.Gender = gender;
                c.DateOfBirth = dob;
                c.Address = provinceMap[provinceCode];// Address đồng bộ với CCCD
                c.PhoneNumber = GeneratePhoneNumber();

                c.Username = "user" + i;
                c.FatherID = "0" + rnd.Next(100000000, 999999999);
                c.MotherID = "0" + rnd.Next(100000000, 999999999);
                c.SpouseID = (rnd.Next(2) == 0) ? "" : "0" + rnd.Next(100000000, 999999999);
                c.Password = c.FullName.Split(' ').Last() + "@" + c.CitizenID.Substring(c.CitizenID.Length - 3);
                c.Occupation = occupations[rnd.Next(occupations.Length)];

                //quy tắt mật khẩu: tên cuối + @ + 3 số cuối CCCD
                string[] parts = c.FullName.Split(' ');
                c.Password = parts[parts.Length - 1] + "@" + c.CitizenID.Substring(c.CitizenID.Length - 3);
                c.Occupation = occupations[rnd.Next(occupations.Length)];

                // THIẾT LẬP MỐI QUAN HỆ THỰC: Lấy ID của những người đã tạo trước đó để làm cha/mẹ
                if (existingIDs.Count > 10) 
                {
                    if (rnd.Next(100) < 60)
                        c.FatherID = existingIDs[rnd.Next(existingIDs.Count)];
                    else
                        c.FatherID = "null";

                    if (rnd.Next(100) < 60)
                        c.MotherID = existingIDs[rnd.Next(existingIDs.Count)];
                    else
                        c.MotherID = "null";
                }
                else
                {
                    c.FatherID = "null";
                    c.MotherID = "null";
                }

                tree.Insert(c);
                existingIDs.Add(id);

                if (tempSample.Count < 5)
                {
                    tempSample.Add(c);
                }

            }
            Console.WriteLine("\n=== DANH SÁCH 5 CÔNG DÂN NGẪU NHIÊN VỪA TẠO ===");
            foreach (Citizen citizen in tempSample)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("ID: " + citizen.CitizenID);
                Console.WriteLine("Pass: " + citizen.Password);
            }
            Console.WriteLine("---------------------------------------\n");
            Console.WriteLine("Admin: admin001 / 123");
            Console.WriteLine("User Test: 001012000001 / An@001");

        }
    }
}
