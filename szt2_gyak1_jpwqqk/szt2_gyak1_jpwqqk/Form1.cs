using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szt2_gyak1_jpwqqk
{
    public partial class Form1 : Form
    {
        BindingList<Student> students = new BindingList<Student>();
        public Form1()
        {
            InitializeComponent();
            dgw.DataSource = students;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            StreamWriter sw = new StreamWriter(sf.FileName, false, Encoding.Default);
            foreach (var s in students)
            {
                sw.Write(s.Neptun);
                sw.Write(";");
                sw.Write(s.Név);
                sw.Write(";");
                sw.Write(s.BirthDate.ToString());
                sw.Write(";");
                sw.Write(s.AverageGrade.ToString());
                sw.Write(";");
                sw.Write(s.IsActive.ToString());
                sw.Write("\n");
            }
            sw.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            students.Clear();
            StreamReader sr = new StreamReader(of.FileName, Encoding.Default);
            while (!sr.EndOfStream)
            {
                string row = sr.ReadLine();
                string[] rowS = row.Split(';');
                Student s = new Student();
                s.Neptun = rowS[0];
                s.Név = rowS[1];
                try
                {
                    s.BirthDate = Convert.ToDateTime(rowS[2]);
                }
                catch { }
                try
                {
                    s.AverageGrade = decimal.Parse(rowS[3]);
                }
                catch
                {

                }
                s.IsActive = bool.Parse(rowS[4]);
                students.Add(s);
                
            }
            sr.Close();
        }
    }
}
