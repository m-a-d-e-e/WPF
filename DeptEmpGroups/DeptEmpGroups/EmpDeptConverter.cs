using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DeptEmpGroups
{
    public class EmpDeptConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TRAININGEntities db = new TRAININGEntities();
            if (value != null)
            {
                DEPT dept = value as DEPT;
                var query = (from d in db.EMPs
                              where d.DEPTNO == dept.DEPTNO
                              select new { Ename = d.ENAME, Job = d.JOB }).ToList();

                return query;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
