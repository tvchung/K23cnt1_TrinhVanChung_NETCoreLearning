namespace TvcLesson07.Models
{
    public class TvcEmployee
    {
        public int TvcId { get; set; }              // Mã nhân viên
        public string TvcName { get; set; }         // Họ tên
        public DateTime TvcBirthDay { get; set; }   // Ngày sinh
        public string TvcEmail { get; set; }        // Email
        public string TvcPhone { get; set; }        // Số điện thoại
        public decimal TvcSalary { get; set; }      // Lương
        public bool TvcStatus { get; set; }         // Trạng thái (true = đang làm việc, false = nghỉ việc)

    }
}
