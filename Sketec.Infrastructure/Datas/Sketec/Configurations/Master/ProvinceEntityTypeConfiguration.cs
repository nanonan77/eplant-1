using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Datas.Configurations
{
    public class ProvinceEntityTypeConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ConfigEntityBaseType();

            builder.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.ProvinceID)
                .HasMaxLength(10)
                .IsUnicode(true);

            builder.Property(e => e.ProvinceThai)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.ZoneID)
                .HasMaxLength(200)
                .IsUnicode(true);


            builder.HasData(
                new Province { Id = 1, Title = "Bangkok", ProvinceID = "10", ProvinceThai = "กรุงเทพมหานคร", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 2, Title = "Samut Prakarn", ProvinceID = "11", ProvinceThai = "สมุทรปราการ", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 3, Title = "Nonthaburi", ProvinceID = "12", ProvinceThai = "นนทบุรี", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 4, Title = "Pathum Thani", ProvinceID = "13", ProvinceThai = "ปทุมธานี", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 5, Title = "Phra Nakhon Si Ayutthaya", ProvinceID = "14", ProvinceThai = "พระนครศรีอยุธยา", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 6, Title = "Ang Thong", ProvinceID = "15", ProvinceThai = "อ่างทอง", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 7, Title = "Lop Buri", ProvinceID = "16", ProvinceThai = "ลพบุรี", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 8, Title = "Sing Buri", ProvinceID = "17", ProvinceThai = "สิงห์บุรี", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 9, Title = "Chai Nat", ProvinceID = "18", ProvinceThai = "ชัยนาท", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 10, Title = "Saraburi", ProvinceID = "19", ProvinceThai = "สระบุรี", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 11, Title = "Chon Buri", ProvinceID = "20", ProvinceThai = "ชลบุรี", ZoneID = "04", IsActive = true, IsDelete = false },
                new Province { Id = 12, Title = "Rayong", ProvinceID = "21", ProvinceThai = "ระยอง", ZoneID = "04", IsActive = true, IsDelete = false },
                new Province { Id = 13, Title = "Chanthaburi", ProvinceID = "22", ProvinceThai = "จันทบุรี", ZoneID = "04", IsActive = true, IsDelete = false },
                new Province { Id = 14, Title = "Trat", ProvinceID = "23", ProvinceThai = "ตราด", ZoneID = "04", IsActive = true, IsDelete = false },
                new Province { Id = 15, Title = "Chachoengsao", ProvinceID = "24", ProvinceThai = "ฉะเชิงเทรา", ZoneID = "04", IsActive = true, IsDelete = false },
                new Province { Id = 16, Title = "Prachin Buri", ProvinceID = "25", ProvinceThai = "ปราจีนบุรี", ZoneID = "04", IsActive = true, IsDelete = false },
                new Province { Id = 17, Title = "Nakhon Nayok", ProvinceID = "26", ProvinceThai = "นครนายก", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 18, Title = "Sa kaeo", ProvinceID = "27", ProvinceThai = "สระแก้ว", ZoneID = "04", IsActive = true, IsDelete = false },
                new Province { Id = 19, Title = "Nakhon Ratchasima", ProvinceID = "30", ProvinceThai = "นครราชสีมา", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 20, Title = "Buri Ram", ProvinceID = "31", ProvinceThai = "บุรีรัมย์", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 21, Title = "Surin", ProvinceID = "32", ProvinceThai = "สุรินทร์", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 22, Title = "Si Sa Ket", ProvinceID = "33", ProvinceThai = "ศรีสะเกษ", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 23, Title = "Ubon Ratchathani", ProvinceID = "34", ProvinceThai = "อุบลราชธานี", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 24, Title = "Yasothon", ProvinceID = "35", ProvinceThai = "ยโสธร", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 25, Title = "Chaiyaphum", ProvinceID = "36", ProvinceThai = "ชัยภูมิ", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 26, Title = "Amnat Charoen", ProvinceID = "37", ProvinceThai = "อำนาจเจริญ", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 27, Title = "Bueng Kan", ProvinceID = "38", ProvinceThai = "บึงกาฬ", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 28, Title = "Nong Bua Lam Phu", ProvinceID = "39", ProvinceThai = "หนองบัวลำภู", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 29, Title = "Khon Kaen", ProvinceID = "40", ProvinceThai = "ขอนแก่น", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 30, Title = "Udon Thani", ProvinceID = "41", ProvinceThai = "อุดรธานี", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 31, Title = "Loei", ProvinceID = "42", ProvinceThai = "เลย", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 32, Title = "Nong Khai", ProvinceID = "43", ProvinceThai = "หนองคาย", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 33, Title = "Maha Sarakham", ProvinceID = "44", ProvinceThai = "มหาสารคาม", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 34, Title = "Roi Et", ProvinceID = "45", ProvinceThai = "ร้อยเอ็ด", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 35, Title = "Kalasin", ProvinceID = "46", ProvinceThai = "กาฬสินธุ์", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 36, Title = "Sakon Nakhon", ProvinceID = "47", ProvinceThai = "สกลนคร", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 37, Title = "Nakhon Phanom", ProvinceID = "48", ProvinceThai = "นครพนม", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 38, Title = "Mukdahan", ProvinceID = "49", ProvinceThai = "มุกดาหาร", ZoneID = "03", IsActive = true, IsDelete = false },
                new Province { Id = 39, Title = "Chiang Mai", ProvinceID = "50", ProvinceThai = "เชียงใหม่", ZoneID = "02", IsActive = true, IsDelete = false },
                new Province { Id = 40, Title = "Lamphun", ProvinceID = "51", ProvinceThai = "ลำพูน", ZoneID = "02", IsActive = true, IsDelete = false },
                new Province { Id = 41, Title = "Lampang", ProvinceID = "52", ProvinceThai = "ลำปาง", ZoneID = "02", IsActive = true, IsDelete = false },
                new Province { Id = 42, Title = "Uttaradit", ProvinceID = "53", ProvinceThai = "อุตรดิตถ์", ZoneID = "02", IsActive = true, IsDelete = false },
                new Province { Id = 43, Title = "Phrae", ProvinceID = "54", ProvinceThai = "แพร่", ZoneID = "02", IsActive = true, IsDelete = false },
                new Province { Id = 44, Title = "Nan", ProvinceID = "55", ProvinceThai = "น่าน", ZoneID = "02", IsActive = true, IsDelete = false },
                new Province { Id = 45, Title = "Phayao", ProvinceID = "56", ProvinceThai = "พะเยา", ZoneID = "02", IsActive = true, IsDelete = false },
                new Province { Id = 46, Title = "Chiang Rai", ProvinceID = "57", ProvinceThai = "เชียงราย", ZoneID = "02", IsActive = true, IsDelete = false },
                new Province { Id = 47, Title = "Mae Hong Son", ProvinceID = "58", ProvinceThai = "แม่ฮ่องสอน", ZoneID = "02", IsActive = true, IsDelete = false },
                new Province { Id = 48, Title = "Nakhon Sawan", ProvinceID = "60", ProvinceThai = "นครสวรรค์", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 49, Title = "Uthai Thani", ProvinceID = "61", ProvinceThai = "อุทัยธานี", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 50, Title = "Kamphaeng Phet", ProvinceID = "62", ProvinceThai = "กำแพงเพชร", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 51, Title = "Tak", ProvinceID = "63", ProvinceThai = "ตาก", ZoneID = "01", IsActive = true, IsDelete = false },
                new Province { Id = 52, Title = "Sukhothai", ProvinceID = "64", ProvinceThai = "สุโขทัย", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 53, Title = "Phitsanulok", ProvinceID = "65", ProvinceThai = "พิษณุโลก", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 54, Title = "Phichit", ProvinceID = "66", ProvinceThai = "พิจิตร", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 55, Title = "Phetchabun", ProvinceID = "67", ProvinceThai = "เพชรบูรณ์", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 56, Title = "Ratchaburi", ProvinceID = "70", ProvinceThai = "ราชบุรี", ZoneID = "01", IsActive = true, IsDelete = false },
                new Province { Id = 57, Title = "Kanchanaburi", ProvinceID = "71", ProvinceThai = "กาญจนบุรี", ZoneID = "01", IsActive = true, IsDelete = false },
                new Province { Id = 58, Title = "Suphan Buri", ProvinceID = "72", ProvinceThai = "สุพรรณบุรี", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 59, Title = "Nakhon Pathom", ProvinceID = "73", ProvinceThai = "นครปฐม", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 60, Title = "Samut Sakhon", ProvinceID = "74", ProvinceThai = "สมุทรสาคร", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 61, Title = "Samut Songkhram", ProvinceID = "75", ProvinceThai = "สมุทรสงคราม", ZoneID = "00", IsActive = true, IsDelete = false },
                new Province { Id = 62, Title = "Phetchaburi", ProvinceID = "76", ProvinceThai = "เพชรบุรี", ZoneID = "01", IsActive = true, IsDelete = false },
                new Province { Id = 63, Title = "Prachuap Khiri Khan", ProvinceID = "77", ProvinceThai = "ประจวบคีรีขันธ์", ZoneID = "01", IsActive = true, IsDelete = false },
                new Province { Id = 64, Title = "Nakhon Si Thammarat", ProvinceID = "80", ProvinceThai = "นครศรีธรรมราช", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 65, Title = "Krabi", ProvinceID = "81", ProvinceThai = "กระบี่", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 66, Title = "Phang-nga", ProvinceID = "82", ProvinceThai = "พังงา", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 67, Title = "Phuket", ProvinceID = "83", ProvinceThai = "ภูเก็ต", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 68, Title = "Surat Thani", ProvinceID = "84", ProvinceThai = "สุราษฎร์ธานี", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 69, Title = "Ranong", ProvinceID = "85", ProvinceThai = "ระนอง", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 70, Title = "Chumphon", ProvinceID = "86", ProvinceThai = "ชุมพร", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 71, Title = "Songkhla", ProvinceID = "90", ProvinceThai = "สงขลา", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 72, Title = "Satun", ProvinceID = "91", ProvinceThai = "สตูล", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 73, Title = "Trang", ProvinceID = "92", ProvinceThai = "ตรัง", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 74, Title = "Phatthalung", ProvinceID = "93", ProvinceThai = "พัทลุง", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 75, Title = "Pattani", ProvinceID = "94", ProvinceThai = "ปัตตานี", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 76, Title = "Yala", ProvinceID = "95", ProvinceThai = "ยะลา", ZoneID = "05", IsActive = true, IsDelete = false },
                new Province { Id = 77, Title = "Narathiwat", ProvinceID = "96", ProvinceThai = "นราธิวาส", ZoneID = "05", IsActive = true, IsDelete = false }
            );
        }
    }
}
