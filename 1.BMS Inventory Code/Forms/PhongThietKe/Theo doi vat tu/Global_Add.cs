using System;
using System.Collections.Generic;
using System.Text;
//using System.Threading.Tasks;

namespace BMS
{
   public class Global_Add
   {
      public static string ConnectionString()
      {
         return "server=localhost;initial catalog=test;uid=root;pwd=123456;port=3306;allow user variables = true;";
      }
      public static FormStatus sFormStatus = 0;
      public static string sIDLinkGridView;
      public static string sIDOrder;
      public static string UserName;

      public static int UserID=2;
      public enum FormStatus
      {
         View = 0,
         Addnew = 1,
         Edit = 2,
         Delete = 3
      }
   }
}