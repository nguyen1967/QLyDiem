using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Xoatt()
        {
            txtMaSV.Text = "";
            txtHoTen.Text = "";
            cbGioiTinh.Text = "";
            txtLop.Text = "";
            txtQueQuan.Text = "";
            txtDiemVan.Text = "";
            txtDiemToan.Text = "";
            txtDiemAnh.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaSV.Text != "" && txtHoTen.Text != "" && cbGioiTinh.Text != "" && txtLop.Text != "" && txtQueQuan.Text != "" )
            {
                try
                {
                    double van = Convert.ToDouble(txtDiemVan.Text);
                    double toan = Convert.ToDouble(txtDiemToan.Text);
                    double anh = Convert.ToDouble(txtDiemAnh.Text);
                    if ( van>=0 && van<=10 && toan >= 0 && toan <= 10 && anh >= 0 && anh <= 10 )
                    {
                        double diemtb = (van + toan + anh) / 3;
                        dataGridViewHS.Rows.Add(txtMaSV.Text, txtHoTen.Text, dateTimePicker1.Text, cbGioiTinh.Text, txtLop.Text, txtQueQuan.Text,
                            txtDiemVan.Text, txtDiemToan.Text, txtDiemAnh.Text,diemtb.ToString());
                        Xoatt();
                        btnXoa.Enabled = true;
                        btnSua.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu điểm phải nằm trong khoảng từ 0 đến 10");
                    }
                }
                catch(FormatException)
                {
                    MessageBox.Show("nhập sai dữ liệu điểm");
                }
            }
            else
            {
                MessageBox.Show("chưa nhập đầy đủ thông tin hs");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int index = dataGridViewHS.CurrentCell.RowIndex;
            dataGridViewHS[0, index].Value = txtMaSV.Text;
            dataGridViewHS[1, index].Value = txtHoTen.Text;
            dataGridViewHS[2, index].Value = dateTimePicker1.Text;
            dataGridViewHS[3, index].Value = cbGioiTinh.Text;
            dataGridViewHS[4, index].Value = txtLop.Text;
            dataGridViewHS[5, index].Value = txtQueQuan.Text;
            dataGridViewHS[6, index].Value = txtDiemVan.Text;
            dataGridViewHS[7, index].Value = txtDiemToan.Text;
            dataGridViewHS[8, index].Value = txtDiemAnh.Text;
            double diemtb = (Convert.ToDouble(txtDiemAnh.Text) + Convert.ToDouble(txtDiemToan.Text) + Convert.ToDouble(txtDiemVan.Text)) / 3;
            dataGridViewHS[9, index].Value = diemtb.ToString();
            Xoatt();
        }

        private void dataGridViewHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewHS.Rows[dataGridViewHS.CurrentCell.RowIndex];
            txtMaSV.Text = row.Cells[0].Value.ToString();
            txtHoTen.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Text = row.Cells[2].Value.ToString();
            cbGioiTinh.Text = row.Cells[3].Value.ToString();
            txtLop.Text = row.Cells[4].Value.ToString();
            txtQueQuan.Text = row.Cells[5].Value.ToString();
            txtDiemVan.Text = row.Cells[6].Value.ToString();
            txtDiemToan.Text = row.Cells[7].Value.ToString();
            txtDiemAnh.Text = row.Cells[8].Value.ToString();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int index = dataGridViewHS.CurrentCell.RowIndex;
                dataGridViewHS.Rows.RemoveAt(index);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (radYeu.Checked)
            {
                dataGridViewTK.Rows.Clear();
                for(int i = 0; i < dataGridViewTK.Rows.Count - 1; i++)
                {
                    double diemtb = Convert.ToDouble(dataGridViewHS[9, i].Value);
                    if(diemtb>=0 && diemtb<4)
                    {
                        dataGridViewTK.Rows.Add(dataGridViewHS[0, i].Value, dataGridViewTK.Rows.Add(dataGridViewHS[1, i].Value),
                            dataGridViewTK.Rows.Add(dataGridViewHS[2, i].Value), dataGridViewTK.Rows.Add(dataGridViewHS[2, i].Value),
                            dataGridViewTK.Rows.Add(dataGridViewHS[4, i].Value), dataGridViewTK.Rows.Add(dataGridViewHS[5, i].Value),
                            dataGridViewTK.Rows.Add(dataGridViewHS[9, i].Value));
                            
                    }    
                }
            }
            else if (radTB.Checked)
            {
                dataGridViewTK.Rows.Clear();
                for (int i = 0; i < dataGridViewTK.Rows.Count - 1; i++)
                {
                    double diemtb = Convert.ToDouble(dataGridViewHS[9, i].Value);
                    if (diemtb >= 4 && diemtb < 5.5)
                    {
                        dataGridViewTK.Rows.Add(dataGridViewHS[0, i].Value, dataGridViewTK.Rows.Add(dataGridViewHS[1, i].Value),
                             dataGridViewTK.Rows.Add(dataGridViewHS[2, i].Value), dataGridViewTK.Rows.Add(dataGridViewHS[2, i].Value),
                             dataGridViewTK.Rows.Add(dataGridViewHS[4, i].Value), dataGridViewTK.Rows.Add(dataGridViewHS[5, i].Value),
                             dataGridViewTK.Rows.Add(dataGridViewHS[9, i].Value));

                    }
                }
            }
            else if (radTBKha.Checked)
            {
                dataGridViewTK.Rows.Clear();
                for (int i = 0; i < dataGridViewTK.Rows.Count - 1; i++)
                {
                    double diemtb = Convert.ToDouble(dataGridViewHS[9, i].Value);
                    if (diemtb >= 5.5 && diemtb < 7)
                    {
                        dataGridViewTK.Rows.Add(dataGridViewHS[0, i].Value, dataGridViewTK.Rows.Add(dataGridViewHS[1, i].Value),
                            dataGridViewTK.Rows.Add(dataGridViewHS[2, i].Value), dataGridViewTK.Rows.Add(dataGridViewHS[2, i].Value),
                            dataGridViewTK.Rows.Add(dataGridViewHS[4, i].Value), dataGridViewTK.Rows.Add(dataGridViewHS[5, i].Value),
                            dataGridViewTK.Rows.Add(dataGridViewHS[9, i].Value));

                    }
                }
            }
            else if (radKha.Checked)
            {
                dataGridViewTK.Rows.Clear();
                for (int i = 0; i < dataGridViewTK.Rows.Count - 1; i++)
                {
                    double diemtb = Convert.ToDouble(dataGridViewHS[9, i].Value);
                    if (diemtb >= 7 && diemtb < 8.5)
                    {
                        dataGridViewTK.Rows.Add(dataGridViewHS[0, i].Value, dataGridViewTK.Rows.Add(dataGridViewHS[1, i].Value),
                            dataGridViewTK.Rows.Add(dataGridViewHS[2, i].Value), dataGridViewTK.Rows.Add(dataGridViewHS[2, i].Value),
                            dataGridViewTK.Rows.Add(dataGridViewHS[4, i].Value), dataGridViewTK.Rows.Add(dataGridViewHS[5, i].Value),
                            dataGridViewTK.Rows.Add(dataGridViewHS[9, i].Value));

                    }
                }
            }
            else if (radGioi.Checked)
            {
                dataGridViewTK.Rows.Clear();
                for (int i = 0; i < dataGridViewTK.Rows.Count - 1; i++)
                {
                    double diemtb = Convert.ToDouble(dataGridViewHS[9, i].Value);
                    if (diemtb >= 8.5 && diemtb <= 10)
                    {
                        dataGridViewTK.Rows.Add(dataGridViewHS[0, i].Value, dataGridViewTK.Rows.Add(dataGridViewHS[1, i].Value),
                               dataGridViewTK.Rows.Add(dataGridViewHS[2, i].Value), dataGridViewTK.Rows.Add(dataGridViewHS[2, i].Value),
                               dataGridViewTK.Rows.Add(dataGridViewHS[4, i].Value), dataGridViewTK.Rows.Add(dataGridViewHS[5, i].Value),
                               dataGridViewTK.Rows.Add(dataGridViewHS[9, i].Value));

                    }
                }
            }
        }
    }
}
