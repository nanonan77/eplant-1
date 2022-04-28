using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sketec.Application.Utils
{
    public partial class SketecUtils
    {
        const string CHAR_LOWWER = "qwertyuiopasdfghjklzxcvbnm";
        const string CHAR_UPPER = "QWERTYUIOPASDFGHJKLZXCVBNM";
        const string NUM = "0123456789";
        const string SPECIAL = "!@#$%^&*()-+_=/";
        static Random random = new Random();
        static readonly object _lock = new object();
        public static string GenerateAccountPassword(int len = 30)
        {
            var st = new StringBuilder();
            for (var i = 0; i < len; i++)
            {
                if (i % 4 == 0)
                    st.Append(ranString(CHAR_LOWWER));
                else if (i % 4 == 1)
                    st.Append(ranString(NUM));
                else if (i % 4 == 2)
                    st.Append(ranString(CHAR_UPPER));
                else
                    st.Append(ranString(SPECIAL));
            }

            return st.ToString();
        }

        static string ranString(string expresstion)
        {
            lock (_lock)
            {
                var idx = random.Next(0, expresstion.Length - 1);
                return expresstion[idx].ToString();
            }
        }

        public static List<string> RoleFilterDataNewRegist()
        {
            return new List<string>(new string[] { "O1", "O2", "D", "R" });
        }

        public static bool IsCanEdit(string team, string report1, string report2, string report3, string pic, string verifier, string section
                        , string userRole, string userTeam, string userEmail, string userSection, string userDepartment, string department)
        {
            List<string> roleList = new List<string>(new string[] { "SS", "M" });
            List<string> roleList2 = new List<string>(new string[] { "O1", "O2" });

            return (roleList.Contains(userRole) && (report1 == userEmail || report2 == userEmail || report3 == userEmail))
                                            || (roleList2.Contains(userRole) && (verifier == userEmail || pic == userEmail))
                                            || (userRole == "D" && section == userSection)
                                            || (userRole == "S" && (
                                                            (section == userSection && !string.IsNullOrWhiteSpace(userSection))
                                                            || (department == userDepartment && string.IsNullOrWhiteSpace(userSection))
                                                            )
                                                )
                                            || userRole == "A";
           
        }
        public static byte[] Combine(byte[] first, byte[] second)
        {
            MemoryStream ms = new MemoryStream();
            using (PdfDocument pdf = new PdfDocument(new PdfWriter(ms).SetSmartMode(true)))
            {
                // Create reader from bytes
                using (MemoryStream memoryStream = new MemoryStream(first))
                {
                    // Create reader from bytes
                    using (PdfReader reader = new PdfReader(memoryStream))
                    {
                        PdfDocument srcDoc = new PdfDocument(reader);
                        srcDoc.CopyPagesTo(1, srcDoc.GetNumberOfPages(), pdf);
                    }
                }

                // Create reader from bytes
                using (MemoryStream memoryStream = new MemoryStream(second))
                {
                    // Create reader from bytes
                    using (PdfReader reader = new PdfReader(memoryStream))
                    {
                        PdfDocument srcDoc = new PdfDocument(reader);
                        srcDoc.CopyPagesTo(1, srcDoc.GetNumberOfPages(), pdf);
                    }
                }
                // Close pdf
                pdf.Close();

            }
            // Return array
            return ms.ToArray();
        }


        public static List<string> RoleAdmin = new List<string>(new string[] { "A" });
        public static List<string> RoleOperation = new List<string>(new string[] { "O1", "O2" });
        public static List<string> RoleSupervisor = new List<string>(new string[] { "S" });
        public static List<string> RoleSectionManager = new List<string>(new string[] { "SS" });
        public static List<string> RoleDepartmentManager = new List<string>(new string[] { "M" });
        public static List<string> RoleDocument = new List<string>(new string[] { "D" });
    }
}
