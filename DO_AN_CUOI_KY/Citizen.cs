using System;
using System.Collections.Generic;

namespace DO_AN_CUOI_KY
{
    [Serializable] 
    public class Citizen
    {
        // --- Thông tin định danh ---
        public string CitizenID { get; set; }        // Số CCCD (Khóa chính)
        public string FullName { get; set; }         // Họ và tên
        public DateTime DateOfBirth { get; set; }    // Ngày sinh
        public string Gender { get; set; }           // Giới tính (Nam/Nữ)
        public string Nationality { get; set; }      // Quốc tịch

        // --- Thông tin tài khoản & Liên lạc ---
        public string Password { get; set; }         // Mật khẩu
        public string Address { get; set; }          // Địa chỉ/Quê quán
        public string PhoneNumber { get; set; }      // Số điện thoại

        // --- Quan hệ gia đình & Công việc ---
        public string FatherID { get; set; }         // ID Cha
        public string MotherID { get; set; }         // ID Mẹ
        public string SpouseID { get; set; }         // ID Vợ/Chồng
        public string Occupation { get; set; }       // Nghề nghiệp

        public Citizen()
        {
            CitizenID = "";
            FullName = "";
            Gender = "Nam";
            Address = "";
            PhoneNumber = "";
            Occupation = "";
            FatherID = "N/A";
            MotherID = "N/A";
            SpouseID = "N/A";
            Nationality = "Việt Nam";
            Password = "123"; 
            DateOfBirth = DateTime.Now;

        }
        public override string ToString()
        {
            return $"{CitizenID} - {FullName}";
        }

    }
}