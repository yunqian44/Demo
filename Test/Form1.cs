using Controls.Controls.DataGridView;
using Controls.DataGridView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {

        public List<ClassName> ClassNames = new List<ClassName>();
        public List<SysCode> SysCodes = new List<SysCode>();

        public Form1()
        {
            InitializeComponent();

            ClassNames.Add(new ClassName() { Code = "001", Name = "一班" });
            ClassNames.Add(new ClassName() { Code = "002", Name = "二班" });

            SysCodes = EnumExtensions.GetDescription<WorkTypeEnum>((a) => { return ((int)Enum.Parse(typeof(WorkTypeEnum), a.ToString())).ToString(); }).ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "编号", Width = 70, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "姓名", Width = 50, WidthType = SizeType.Percent, CellType = CellTypeEnum.Text });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "年龄", Width = 50, WidthType = SizeType.Percent, CellType = CellTypeEnum.NumericUpDown });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "生日", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((DateTime)a).ToString("yyyy-MM-dd"); } });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "性别", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((int)a) == 0 ? "女" : "男"; } });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "WorkType", HeadText = "工作类型", Width = 50, WidthType = SizeType.Percent, CellType = CellTypeEnum.ComboBox, DataSource = SysCodes, TextFildName = "CodeName", ValueFildName = "CodeId", Format = (a) => GetWorkTypeEnumDescript((WorkTypeEnum)a), BindControlName= "ClassName",BindEvent=(a,b)=> WorkTypeValueChange((Control)a, (Control)b) });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ClassName", HeadText = "班级名称", Width = 50, WidthType = SizeType.Percent, CellType = CellTypeEnum.ComboBox, DataSource = ClassNames, Format= (a)=>FindClassName(a.ToString()), TextFildName = "Name", ValueFildName = "Code" });
            this.gv.Columns = lstCulumns;
            this.gv.IsShowCheckBox = true;
            List<object> lstSource = new List<object>();
            for (int i = 0; i < 2; i++)
            {
                TestModel model = new TestModel()
                {
                    ID = i.ToString(),
                    Age = 3 * i,
                    Name = "姓名——" + i,
                    Birthday = DateTime.Now.AddYears(-10),
                    Sex = i % 2,
                    WorkType = WorkTypeEnum.Doctor,
                    ClassName = i % 2 == 0 ? "001" : "002"
                };
                lstSource.Add(model);
            }

            this.gv.DataSource = lstSource;
        }

        public string GetWorkTypeEnumDescript(WorkTypeEnum workType)
        {
            return workType.GetDescription();
        }

        public string FindClassName(string Code)
        {
            var name = string.Empty;
            if (!string.IsNullOrEmpty(Code))
            {
                var model= ClassNames.Where(u => u.Code.Equals(Code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (model != null)
                {
                    name = model.Name;
                }
            }
            return name;
        }

        private void WorkTypeValueChange(Control eventSourceControl, Control control)
        {
            var  sourceControl= eventSourceControl as ComboBox;
            var newControl = control as ComboBox;
            if (sourceControl.Items != null
                &&sourceControl.Items.Count>0
                && newControl.Items != null
                && newControl.Items.Count>0)
            {
                if (sourceControl.SelectedValue.ToString() == ((int)WorkTypeEnum.Teacher).ToString())
                {
                    newControl.SelectedValue = ClassNames.Where(u => u.Name == "二班").FirstOrDefault().Code;
                }
                else
                {
                    newControl.SelectedValue = ClassNames.Where(u => u.Name == "一班").FirstOrDefault().Code;
                }
            }
        }


        public class TestModel
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime Birthday { get; set; }
            public int Sex { get; set; }

            public WorkTypeEnum WorkType { get; set; }

            public string ClassName { get; set; }
        }

        public enum WorkTypeEnum
        {
            /// <summary>
            /// 教师
            /// </summary>
            [Description("教师")]
            Teacher=10,

            /// <summary>
            /// 医生
            /// </summary>
            [Description("医生")]
            Doctor = 20
        }

        public class ClassName
        {
            public string Code { get; set; }

            public string Name { get; set; }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            gv.AddRow(new { Name="你好",Age=20,WorkType=WorkTypeEnum.Doctor,ClassName="001"});
            //gv.ReloadSource(5);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (gv.SelectRows.Count > 0)
            {
                if (gv.SelectRows.Count == 1)
                {
                    int index = gv.SelectRows[0].RowIndex;
                    gv.RemoveRow(index);
                }
                else
                {
                    MessageBox.Show("请选择一条信息进行移除操作");
                }
            }
            else
            {
                MessageBox.Show("请选择一条信息进行移除操作");
            }
            
        }
    }
}
