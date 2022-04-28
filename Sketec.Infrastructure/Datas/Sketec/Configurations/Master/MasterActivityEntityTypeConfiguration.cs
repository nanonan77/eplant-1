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
    public class MasterActivityEntityTypeConfiguration : IEntityTypeConfiguration<MasterActivity>
    {
        public void Configure(EntityTypeBuilder<MasterActivity> builder)
        {
            builder.ConfigEntityBaseType();

            builder.Property(e => e.ActivityEN)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.ActivityTH)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.ActivityCode)
                .HasMaxLength(10)
                .IsUnicode(true);

            builder.HasData(
                new MasterActivity { Id = 1, ActivityCode = "A01", ActivityTH = "ค่าเช่าที่ดิน", ActivityEN = "Rental", MasterActivityTypeId = 1, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 2, ActivityCode = "A02", ActivityTH = "ค่าแบ่งปันผลประโยชน์ / ผลกำไร", ActivityEN = "Share benefit / profit", MasterActivityTypeId = 1, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 3, ActivityCode = "A03", ActivityTH = "ค่านายหน้า", ActivityEN = "Commission", MasterActivityTypeId = 1, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 4, ActivityCode = "A00", ActivityTH = "อื่นๆ", ActivityEN = "Others", MasterActivityTypeId = 1, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 5, ActivityCode = "B01", ActivityTH = "ขุดตอ เก็บริบ&สุมเผา&ทำร่องน้ำ", ActivityEN = "Site Preparation : Land clearing", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 6, ActivityCode = "B02", ActivityTH = "ลง ripper", ActivityEN = "Site Preparation : Ripper", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 7, ActivityCode = "B03", ActivityTH = "ไถบุกเบิก (ผาน 3)", ActivityEN = "Plough soil with 3 disks tractor ", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 8, ActivityCode = "B04", ActivityTH = "ไถพรวนดิน (ผาน 7)", ActivityEN = "Plough soil with 7 disks tractor", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 9, ActivityCode = "B05", ActivityTH = "ปรับปรุงคุณภาพดินด้วย Sludge", ActivityEN = "Improve soil quality by Sludge", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 10, ActivityCode = "B06", ActivityTH = "ปรับปรุงคุณภาพดินด้วยปุ๋ยอินทรีย์", ActivityEN = "Improve soil quality by Org.Fertilizer", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 11, ActivityCode = "B07", ActivityTH = "ปรับปรุงคุณภาพดินด้วย Sludge (เครื่องพ่น)", ActivityEN = "Improve soil quality by Sludge (Machine)", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 12, ActivityCode = "B08", ActivityTH = "ลง ripper ยกร่อง ใส่ sludge", ActivityEN = "Site Preparation : Ripper & Trench & Sludge", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 13, ActivityCode = "B09", ActivityTH = "รองก้นหลุมด้วย Sludge /ปุ๋ย อินทรีย์ (รอบตัดฟัน#1)", ActivityEN = "", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 14, ActivityCode = "B10", ActivityTH = "ฉีดยาคุมหญ้า", ActivityEN = "", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 15, ActivityCode = "B11", ActivityTH = "ลง Ripper 60 cm.", ActivityEN = "", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 16, ActivityCode = "B12", ActivityTH = "ยกร่อง", ActivityEN = "", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 17, ActivityCode = "B13", ActivityTH = "ค่าแรงคนขับรถไถ & OT & ค่าเช่ารถ", ActivityEN = "Wage / Salary & OT Tractor driver / Machine rental", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 18, ActivityCode = "B14", ActivityTH = "ค่าน้ำมันดีเซล", ActivityEN = "Diesel", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 19, ActivityCode = "B15", ActivityTH = "ค่าน้ำมันเครื่อง", ActivityEN = "Lubricant, Lube", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 20, ActivityCode = "B16", ActivityTH = "ค่าอะไหล่", ActivityEN = "Spare parts,", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 21, ActivityCode = "B17", ActivityTH = "ค่าซ่อม/บำรุง เครื่องจักร", ActivityEN = "Maintenance", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 22, ActivityCode = "B18", ActivityTH = "ค่าขนย้ายรถ", ActivityEN = "Moving & transport", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 23, ActivityCode = "B00", ActivityTH = "อื่นๆ", ActivityEN = "Site Preparation : Others", MasterActivityTypeId = 2, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 24, ActivityCode = "C01", ActivityTH = "ค่ากล้าไม้", ActivityEN = "Planting : Seedling", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 25, ActivityCode = "C02", ActivityTH = "วางแนว & ปลูก", ActivityEN = "Planting : Strip line", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 26, ActivityCode = "C03", ActivityTH = "วางแนว & ขุดหลุมปลูก (แรงงาน)", ActivityEN = "Planting : Digging a hole by labor", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 27, ActivityCode = "C04", ActivityTH = "วางแนว & เจาะหลุมปลูก (แรงงาน)", ActivityEN = "Planting : Drill a hole by labor", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 28, ActivityCode = "C05", ActivityTH = "วางแนว & เจาะหลุมปลูก (รถไถ)", ActivityEN = "Planting : Drill a hole by tractor", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 29, ActivityCode = "C06", ActivityTH = "ใส่โพลิเมอร์รองก้นหลุม ", ActivityEN = "Planting : Put polymer on the bottom ", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 30, ActivityCode = "C07", ActivityTH = "ใส่ปุ๋ยละลายช้ารองก้นหลุม", ActivityEN = "Planting : Put osmocote fert. on the bottom", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 31, ActivityCode = "C08", ActivityTH = "ใส่ Sludg รองก้นหลุม", ActivityEN = "Planting : Put sludge on the bottom", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 32, ActivityCode = "C09", ActivityTH = "รดน้ำ", ActivityEN = "Planting : Watering", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 33, ActivityCode = "C10", ActivityTH = "ปลูกซ่อม", ActivityEN = "Planting : Blanking", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 34, ActivityCode = "C11", ActivityTH = "ค่าสารปรับปรุงดิน (ปุ๋ย หรือ อื่นๆ)", ActivityEN = "", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 35, ActivityCode = "C12", ActivityTH = "ค่ากำจัดวัชพืชรอบโคน", ActivityEN = "", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 36, ActivityCode = "C13", ActivityTH = "ปลูกด้วยเครื่องติดแทรกเตอร์ ", ActivityEN = "", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 37, ActivityCode = "C14", ActivityTH = "ปลูกเจาะหลุมด้วยแทรกเตอร์", ActivityEN = "", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 38, ActivityCode = "C15", ActivityTH = "ค่าแรงคนขับรถไถ & OT & ค่าเช่ารถ", ActivityEN = "Wage / Salary & OT Tractor driver / Machine rental", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 39, ActivityCode = "C16", ActivityTH = "ค่าน้ำมันดีเซล", ActivityEN = "Diesel", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 40, ActivityCode = "C17", ActivityTH = "ค่าน้ำมันเครื่อง", ActivityEN = "Lubricant, Lube", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 41, ActivityCode = "C18", ActivityTH = "ค่าอะไหล่", ActivityEN = "Spare parts,", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 42, ActivityCode = "C19", ActivityTH = "ค่าซ่อม/บำรุง เครื่องจักร", ActivityEN = "Maintenance", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 43, ActivityCode = "C20", ActivityTH = "ค่าขนย้ายรถ", ActivityEN = "Moving & transport", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 44, ActivityCode = "C00", ActivityTH = "อื่นๆ", ActivityEN = "Planting : Others", MasterActivityTypeId = 3, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 45, ActivityCode = "D01", ActivityTH = "แต่งหน่อ ", ActivityEN = "Coppice Thinning", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 46, ActivityCode = "D02", ActivityTH = "ถากรอบโคน (0.5 m)", ActivityEN = "Weeding control by manaul (0.5 m)", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 47, ActivityCode = "D03", ActivityTH = "หวดกำจัดวัชพืช", ActivityEN = "Weeding control by manaul", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 48, ActivityCode = "D04", ActivityTH = "ฉีด/พ่น ยาฆ่าหญ้า, ยาฆ่าแมลง,สารเคมี (แรงงาน)", ActivityEN = "Weeding control by chemical (manaul)", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 49, ActivityCode = "D05", ActivityTH = "ฉีด/พ่น ยาฆ่าหญ้า, ยาฆ่าแมลง,สารเคมี (โดรน)", ActivityEN = "Weeding control by chemical (drone)", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 50, ActivityCode = "D06", ActivityTH = "ไถกากบาท", ActivityEN = "Weeding control by tractor : cross", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 51, ActivityCode = "D07", ActivityTH = "ไถแนวเดียว ร่อง 3 ม.", ActivityEN = "Weeding control by tractor : 1 column (3 m)", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 52, ActivityCode = "D08", ActivityTH = "ไถแนวเดียว ร่อง 2 ม.", ActivityEN = "Weeding control by tractor : 1 column (2 m)", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 53, ActivityCode = "D09", ActivityTH = "ค่าปุ๋ยเคมี", ActivityEN = "Chem fert.", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 54, ActivityCode = "D10", ActivityTH = "ค่าปุ๋ยอินทรีย์", ActivityEN = "Organic fert.", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 55, ActivityCode = "D11", ActivityTH = "ค่า sludge", ActivityEN = "Sludge", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 56, ActivityCode = "D12", ActivityTH = "ขุดหลุมฝังกลบ 2 ข้าง", ActivityEN = "Fertilizing : Digging 2 holes", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 57, ActivityCode = "D13", ActivityTH = "หว่านรอบโคนต้น", ActivityEN = "Fertilizing : sowing", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 58, ActivityCode = "D14", ActivityTH = "ทำแนวกันไฟ", ActivityEN = "Fire control : Fire brake", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 59, ActivityCode = "D15", ActivityTH = "รดน้ำ", ActivityEN = "Maintenance : Watering", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 60, ActivityCode = "D16", ActivityTH = "ค่าใส่ปุ๋ย เครื่องจักร", ActivityEN = "", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 61, ActivityCode = "D17", ActivityTH = "ค่าหว่านปุ๋ยเม็ดด้วยแทรกเตอร์ ", ActivityEN = "", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 62, ActivityCode = "D18", ActivityTH = "ฉีด/พ่น สารเคมีแทรกเตอร์ ", ActivityEN = "", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 63, ActivityCode = "D19", ActivityTH = "ค่าปั่นโรตารี่ตีดิน ", ActivityEN = "", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 64, ActivityCode = "D20", ActivityTH = "ค่าตัดหญ้า ด้วยแทรกเตอร์", ActivityEN = "", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 65, ActivityCode = "D21", ActivityTH = "ค่าดันแปลง/ดันถนนรอบแปลง ", ActivityEN = "", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 66, ActivityCode = "D22", ActivityTH = "ค่าแรงคนขับรถไถ & OT & ค่าเช่ารถ", ActivityEN = "Wage / Salary & OT Tractor driver / Machine rental", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 67, ActivityCode = "D23", ActivityTH = "ค่าน้ำมันดีเซล", ActivityEN = "Diesel", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 68, ActivityCode = "D24", ActivityTH = "ค่าน้ำมันเครื่อง", ActivityEN = "Lubricant, Lube", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 69, ActivityCode = "D25", ActivityTH = "ค่าอะไหล่", ActivityEN = "Spare parts,", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 70, ActivityCode = "D26", ActivityTH = "ค่าซ่อม/บำรุง เครื่องจักร", ActivityEN = "Maintenance", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 71, ActivityCode = "D27", ActivityTH = "ค่าขนย้ายรถ", ActivityEN = "Moving & transport", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 72, ActivityCode = "D00", ActivityTH = "อื่นๆ", ActivityEN = "Maintenance : Others", MasterActivityTypeId = 4, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 73, ActivityCode = "F01", ActivityTH = "จดทะเบียนเช่า, ค่าสาธารณูปโภค, ค่าดำเนินการตามกฏหมาย ,ค่าพนักงานสวนไม้,คนเฝ้าแปลง ฯลฯ", ActivityEN = "Administrative fee, Public utility, Annual fee", MasterActivityTypeId = 6, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 74, ActivityCode = "F02", ActivityTH = "อากรแสตมป์, ภาษีบำรุงท้องที่, ภาษีตามกฏหมาย", ActivityEN = "Tax", MasterActivityTypeId = 6, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 75, ActivityCode = "F03", ActivityTH = "ค่าสนับสนุน, เงินบริจาค", ActivityEN = "Donation, Gift, Contribution,", MasterActivityTypeId = 6, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 76, ActivityCode = "F04", ActivityTH = "ค่าวัสดุอุปกรณ์", ActivityEN = "Tool, Equipment, ", MasterActivityTypeId = 6, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 77, ActivityCode = "F05", ActivityTH = "ค่าซ่อมบำรุง สถานที่ / สำนักงาน", ActivityEN = "Office maintenance", MasterActivityTypeId = 6, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 78, ActivityCode = "F06", ActivityTH = "ค่าที่พัก", ActivityEN = "Lodging", MasterActivityTypeId = 6, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 79, ActivityCode = "F07", ActivityTH = "ค่าประเมินอัตรารอดตาย", ActivityEN = "Monitoring : %Surv.", MasterActivityTypeId = 6, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 80, ActivityCode = "F08", ActivityTH = "ค่าประเมินผลผลิต (ความโต)", ActivityEN = "Forest inventory : Growth", MasterActivityTypeId = 6, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 81, ActivityCode = "F00", ActivityTH = "อื่นๆ", ActivityEN = "Others", MasterActivityTypeId = 6, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 82, ActivityCode = "E01", ActivityTH = "ค่าตัดไม้ (แรงงานคน)", ActivityEN = "Harvesting (Labor)", MasterActivityTypeId = 5, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 83, ActivityCode = "E02", ActivityTH = "ค่าตัดไม้ (รถตัด)", ActivityEN = "Harvesting (Machine)", MasterActivityTypeId = 5, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 84, ActivityCode = "H01", ActivityTH = "ค่าขนส่งไม้ท่อน", ActivityEN = "Wood Log Transportation", MasterActivityTypeId = 8, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 85, ActivityCode = "G01", ActivityTH = "ค่าไม้ท่อน", ActivityEN = "Wood Log", MasterActivityTypeId = 7, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 86, ActivityCode = "G02", ActivityTH = "ค่าไม้ชีวมวล", ActivityEN = "Biomass", MasterActivityTypeId = 7, IsActive = true, IsDelete = false },
                new MasterActivity { Id = 87, ActivityCode = "G00", ActivityTH = "รายรับอื่นๆ", ActivityEN = "Others", MasterActivityTypeId = 7, IsActive = true, IsDelete = false }
            );


           
        }
    }
}
