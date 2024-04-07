using BaseSolution.Domain.Enums;

namespace BaseSolution.Infrastructure.Extensions
{
    public class EntityStatusExtensions
    {

        public string ConvertForGeneral(EntityStatus status)
        {
            switch (status)
            {
                case EntityStatus.Active:
                    return "Đang hoạt động";
                case EntityStatus.InActive:
                    return "Ngừng hoạt động";
                case EntityStatus.Deleted:
                    return "Đã xóa";
                case EntityStatus.Pending:
                    return "Đang chờ";
                case EntityStatus.Locked:
                    return "Đã khóa";
            }

            return "N/A";
        }

        public string ConvertForCountry(EntityCountry status)
        {
            switch (status)
            {
                case EntityCountry.VN:
                    return "Việt Nam";
                case EntityCountry.CN:
                    return "Trung Quốc";
                case EntityCountry.US:
                    return "Mỹ";
                case EntityCountry.CA:
                    return "Canada";
                case EntityCountry.DE:
                    return "Đức";
                case EntityCountry.SG:
                    return "Singapore";
            }

            return "N/A";
        }
        public string ConvertForDistrict(EntityDistrict status)
        {
            switch (status)
            {
                case EntityDistrict.TK:
                    return "Thanh Khê";
                case EntityDistrict.CL:
                    return "Cẩm Lệ";
                case EntityDistrict.BD:
                    return "Ba Đình";
                case EntityDistrict.NTL:
                    return "Nam Từ Liêm";
                case EntityDistrict.TP:
                    return "Tân Phú";
                case EntityDistrict.CG:
                    return "Cầu Giấy";
                case EntityDistrict.HBT:
                    return "Hai Bà Trưng";
                case EntityDistrict.ZN:
                    return "Trường Ninh";
                case EntityDistrict.MHT:
                    return "Manhattan";
                case EntityDistrict.TU:
                    return "Tân Uyên";
                case EntityDistrict.TA:
                    return "Thuận An";
                case EntityDistrict.BT:
                    return "Bình Tân";
            }
            return "N/A";
        }

        public string ConvertForCity(EntityCity status)
        {
            switch (status)
            {
                case EntityCity.HN:
                    return "Hà Nội";  
                case EntityCity.NY:
                    return "NewYork";
                case EntityCity.QB:
                    return "Quảng Bình";
                case EntityCity.BN:
                    return "Bắc Ninh";
                case EntityCity.BD:
                    return "Bình Dương";
                case EntityCity.SZ:
                    return "Thẩm Quyến";
                case EntityCity.VC:
                    return "Vancouver";
                case EntityCity.TQ:
                    return "Tuyên Quang";
                case EntityCity.TH:
                    return "Thanh Hóa";
                case EntityCity.HCM:
                    return "Hồ Chí Minh";
                case EntityCity.DN:
                    return "Đà Nẵng";
                case EntityCity.HG:
                    return "Hà Giang";
                case EntityCity.QN:
                    return "Quảng Ngãi";
                case EntityCity.BK:
                    return "Bắc Kạn";
                case EntityCity.LC:
                    return "Lai Châu";
                case EntityCity.SL:
                    return "Sơn La";
                case EntityCity.SH:
                    return "Thượng Hải";
                case EntityCity.BL:
                    return "Berlin";
                case EntityCity.CB:
                    return "Cao Bằng";
            }
            return "N/A";
        }
        public string ConvertForExample(EntityStatus status)
        {
            switch (status)
            {
                case EntityStatus.Active:
                    return "Đang mở";
                case EntityStatus.InActive:
                    return "Đang đóng";
                case EntityStatus.Deleted:
                    return "Đã xóa";
                case EntityStatus.Pending:
                    return "Đang chờ";
                case EntityStatus.Locked:
                    return "Đã khóa";
            }
            return "N/A";
        }
    }
}
