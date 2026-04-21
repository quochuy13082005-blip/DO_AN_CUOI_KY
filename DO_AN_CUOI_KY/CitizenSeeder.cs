using System;
using System.Collections.Generic;
using System.Linq;

namespace DO_AN_CUOI_KY
{
    public class CitizenSeeder
    {
        // =========================================================
        // 1. DỮ LIỆU MẪU
        // =========================================================
        static Random rnd = new Random();

        static string[] phonePrefixes = { "090", "091", "098", "032", "035", "038", "070", "077", "083", "085" };

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

        static HashSet<string> usedIDs = new HashSet<string>();

        // =========================================================
        // 2. HÀM SINH DỮ LIỆU NGẪU NHIÊN 
        // =========================================================
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
            string suffix = rnd.Next(0, 10000000).ToString("D7"); 
            return prefix + suffix;
        }

        // =========================================================
        // 3. LOGIC XỬ LÝ CHÍNH 
        // =========================================================
        public static void Seed(BinarySearchTree tree, int n = 1000)
        {
            CreateFixedAccounts(tree);// --- Tạo tài khoản cố định để Test ---

            List<Citizen> tempSample = new List<Citizen>();
            List<Citizen> allCitizens = new List<Citizen>();
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
                c.Address = provinceMap[provinceCode];
                c.PhoneNumber = GeneratePhoneNumber();
                c.Occupation = occupations[rnd.Next(occupations.Length)];

                //Taọ mật khẩu theo quy tắc: Tên không dấu + @ + 3 số cuối của ID  
                string rawName = c.FullName.Split(' ').Last();
                string nameNoSign = RemoveDiacritics(rawName);
                string formattedName = char.ToUpper(nameNoSign[0]) + nameNoSign.Substring(1).ToLower();
                string lastThreeId = c.CitizenID.Substring(c.CitizenID.Length - 3);
                string finalPassword = formattedName + "@" + lastThreeId;

                allCitizens.Add(c);

                if (finalPassword.Length < 6)
                {
                    finalPassword = formattedName + "@" + lastThreeId;
                }

                c.Password = finalPassword;
            }
            AssignFamilyLogic(allCitizens);
            AssignSpouseLogic(allCitizens);

            for (int i = 0; i < allCitizens.Count; i++)
            {
                tree.Insert(allCitizens[i]);
            }
            PrintSeedResults(tempSample);
        }

        // =========================================================
        // 4. CÁC HÀM HỖ TRỢ 
        // =========================================================
        private static void CreateFixedAccounts(BinarySearchTree tree)
        {
            // Admin
            tree.Insert(new Citizen
            {
                CitizenID = "admin001",
                FullName = "Quản Trị Viên",
                Password = "123",
                Address = "Hệ thống"
            });
            // User Test
            tree.Insert(new Citizen
            {
                CitizenID = "001012000001",
                FullName = "Nguyễn Văn An",
                Password = "An@001",
                DateOfBirth = new DateTime(2000, 1, 1),
                Address = "Hà Nội"
            });
        }

        static void AssignFamilyLogic(List<Citizen> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Citizen child = list[i];

                List<Citizen> fathers = list
                    .Where(p => p.Gender == "Nam" &&
                                p.DateOfBirth <= child.DateOfBirth.AddYears(-18))
                    .ToList();

                List<Citizen> mothers = list
                    .Where(p => p.Gender == "Nữ" &&
                                p.DateOfBirth <= child.DateOfBirth.AddYears(-18))
                    .ToList();

                if (fathers.Count > 0 && mothers.Count > 0)
                {
                    Citizen father = fathers[rnd.Next(fathers.Count)];
                    Citizen mother = mothers[rnd.Next(mothers.Count)];

                    if (father.CitizenID != child.CitizenID &&
                        mother.CitizenID != child.CitizenID)
                    {
                        child.FatherID = father.CitizenID;
                        child.MotherID = mother.CitizenID;
                    }
                }
                else
                {
                    child.FatherID = "null";
                    child.MotherID = "null";
                }
            }
        }

        static void AssignSpouseLogic(List<Citizen> list)
        {
            List<Citizen> males = list
                .Where(x => x.Gender == "Nam" && x.SpouseID == "null")
                .ToList();

            List<Citizen> females = list
                .Where(x => x.Gender == "Nữ" && x.SpouseID == "null")
                .ToList();

            foreach (Citizen male in males)
            {
                if (male.DateOfBirth > DateTime.Now.AddYears(-18)) continue;

                List<Citizen> candidates = new List<Citizen>();

                foreach (Citizen female in females)
                {
                    if (female.SpouseID != "null") continue;

                    if (female.DateOfBirth > DateTime.Now.AddYears(-18)) continue;

                    double ageDiff = Math.Abs((female.DateOfBirth - male.DateOfBirth).TotalDays);

                    if (ageDiff <= 3650) 
                    {
                        if (female.CitizenID != male.FatherID &&
                            female.CitizenID != male.MotherID &&
                            male.CitizenID != female.FatherID &&
                            male.CitizenID != female.MotherID)
                        {
                            candidates.Add(female);
                        }
                    }
                }

                if (candidates.Count > 0 && rnd.Next(100) < 40)
                {
                    Citizen wife = candidates[rnd.Next(candidates.Count)];

                    male.SpouseID = wife.CitizenID;
                    wife.SpouseID = male.CitizenID;
                }
            }
        }

        private static void PrintSeedResults(List<Citizen> tempSample)
        {
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

        private static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            string[] vietnameseSigns = new string[]
            {
                    "aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                    "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ", "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                    "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ","íìịỉĩ", "ÍÌỊỈĨ", "đ", "Đ","ýỳỵỷỹ", "ÝỲỴỶỸ"
            };

            for (int i = 1; i < vietnameseSigns.Length; i++)
            {
                for (int j = 0; j < vietnameseSigns[i].Length; j++)
                    text = text.Replace(vietnameseSigns[i][j], vietnameseSigns[0][i - 1]);
            }
            return text;
        }
    }
}
