using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Context;
using System.Data.Entity;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MHEntities context = new MHEntities();
        public Form1()
        {
            InitializeComponent();

            dgvMyFriend.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            dataGridView4.AutoGenerateColumns = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                #region KisiyiBul
                long no = 0;
                string adSoyad = textBox2.Text;
                List<VW_Ogrenci_Network> arkadasListem = new List<VW_Ogrenci_Network>();

                VW_Ogrenci_Network secilenKisi;
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    secilenKisi = context.VW_Ogrenci_Network.Where(a => a.AdSoyad == adSoyad).FirstOrDefault();
                    if (secilenKisi != null)
                    {
                        no = secilenKisi.No;
                        lbl9.Text = secilenKisi.No + " - " + secilenKisi.AdSoyad;
                    }

                }
                else
                {
                    no = Convert.ToInt64(textBox1.Text);
                    secilenKisi = context.VW_Ogrenci_Network.Where(a => a.No == no).FirstOrDefault();
                    if (secilenKisi != null)
                        lbl9.Text = secilenKisi.No + " - " + secilenKisi.AdSoyad;
                }
                if (secilenKisi == null)
                {
                    MessageBox.Show("Aradağınız kişi bulunamadı lütfen alanları doğru giriniz..!");
                    return;
                }
                #endregion

                string[] array = secilenKisi.Network.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != "" && array[i].Length == 10)
                    {
                        long gelenNo = Convert.ToInt64(array[i]);
                        VW_Ogrenci_Network og = context.VW_Ogrenci_Network.FirstOrDefault(a => a.No == gelenNo);
                        if (og != null)
                            arkadasListem.Add(og);
                    }
                }

                dgvMyFriend.DataSource = arkadasListem;
                label2.Text = arkadasListem.Count.ToString();

                var digerList = context.VW_Ogrenci_Network.ToList();
                foreach (var item in arkadasListem)
                {
                    digerList.Remove(item);
                }

                dataGridView1.DataSource = digerList;
                label4.Text = digerList.Count.ToString();

                List<VW_Ogrenci_Network> egitimSetiPaket1 = arkadasListem.ToList();
                foreach (var item in egitimSetiPaket1)
                {
                    item.Label = 1;
                }

                List<VW_Ogrenci_Network> egitimSetiPaket2 = digerList.Take(digerList.Count / 2).ToList();
                List<VW_Ogrenci_Network> egitimSeti = new List<VW_Ogrenci_Network>();

                egitimSeti.AddRange(egitimSetiPaket1);
                egitimSeti.AddRange(egitimSetiPaket2);

                dataGridView2.DataSource = egitimSeti;
                label5.Text = egitimSeti.Count.ToString();

                List<VW_Ogrenci_Network> testSeti = context.VW_Ogrenci_Network.ToList();
                foreach (var item in egitimSetiPaket2)
                    testSeti.Remove(item);

                dataGridView3.DataSource = testSeti.OrderByDescending(a => a.Label).ToList();
                label3.Text = testSeti.Count.ToString();

                #region Formul
                double toplam;
                double[] B = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                double[] B1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                for (int i = 0; i < 1000; i++)
                {
                    toplam = 0;
                    for (int j = 0; j < egitimSeti.Count; j++)
                    {
                        string[] x = egitimSeti[j].Cevap.Split(',');

                        toplam = toplam + (1 / (1 + Math.Pow(Math.E
                            , -(B[0] + B[1] * Convert.ToDouble(x[0]) +
                                       B[2] * Convert.ToDouble(x[1]) +
                                       B[3] * Convert.ToDouble(x[2]) +
                                       B[4] * Convert.ToDouble(x[3]) +
                                       B[5] * Convert.ToDouble(x[4]) +
                                       B[6] * Convert.ToDouble(x[5]) +
                                       B[7] * Convert.ToDouble(x[6]) +
                                       B[8] * Convert.ToDouble(x[7]) +
                                       B[9] * Convert.ToDouble(x[8]) +
                                       B[10] * Convert.ToDouble(x[9]) +
                                       B[11] * Convert.ToDouble(x[10]) +
                                       B[12] * Convert.ToDouble(x[11]) +
                                       B[13] * Convert.ToDouble(x[12]) +
                                       B[14] * Convert.ToDouble(x[13]) +
                                       B[15] * Convert.ToDouble(x[14]))))) - egitimSeti[j].Label;

                    }
                    B1[0] = B[0] - (toplam / egitimSeti.Count * 0.001);

                    for (int k = 0; k < 15; k++)
                    {
                        toplam = 0;
                        for (int j = 0; j < egitimSeti.Count; j++)
                        {
                            string[] x = egitimSeti[j].Cevap.Split(',');

                            toplam = toplam + ((1 / (1 + Math.Pow(Math.E
                                , -(B[0] + B[1] * Convert.ToDouble(x[0]) +
                                           B[2] * Convert.ToDouble(x[1]) +
                                           B[3] * Convert.ToDouble(x[2]) +
                                           B[4] * Convert.ToDouble(x[3]) +
                                           B[5] * Convert.ToDouble(x[4]) +
                                           B[6] * Convert.ToDouble(x[5]) +
                                           B[7] * Convert.ToDouble(x[6]) +
                                           B[8] * Convert.ToDouble(x[7]) +
                                           B[9] * Convert.ToDouble(x[8]) +
                                           B[10] * Convert.ToDouble(x[9]) +
                                           B[11] * Convert.ToDouble(x[10]) +
                                           B[12] * Convert.ToDouble(x[11]) +
                                           B[13] * Convert.ToDouble(x[12]) +
                                           B[14] * Convert.ToDouble(x[13]) +
                                           B[15] * Convert.ToDouble(x[14]))))) - egitimSeti[j].Label) * Convert.ToDouble(x[k]);

                        }
                        B1[k + 1] = B[k + 1] - (toplam / egitimSeti.Count * 0.001);

                    }

                    for (int m = 0; m < B1.Length; m++)
                    {
                        B[m] = B1[m];
                    }

                }
                var tumKisiler = context.VW_Ogrenci_Network.ToList();
                for (int i = 0; i < tumKisiler.Count; i++)
                {
                    VW_Ogrenci_Network ogrenci = tumKisiler[i];
                    string[] ogC = ogrenci.Cevap.Split(',');
                    ogrenci.Puan = (1 / (1 + Math.Pow(Math.E
                            , -(B[0] + B[1] * Convert.ToDouble(ogC[0]) +
                                       B[2] * Convert.ToDouble(ogC[1]) +
                                       B[3] * Convert.ToDouble(ogC[2]) +
                                       B[4] * Convert.ToDouble(ogC[3]) +
                                       B[5] * Convert.ToDouble(ogC[4]) +
                                       B[6] * Convert.ToDouble(ogC[5]) +
                                       B[7] * Convert.ToDouble(ogC[6]) +
                                       B[8] * Convert.ToDouble(ogC[7]) +
                                       B[9] * Convert.ToDouble(ogC[8]) +
                                       B[10] * Convert.ToDouble(ogC[9]) +
                                       B[11] * Convert.ToDouble(ogC[10]) +
                                       B[12] * Convert.ToDouble(ogC[11]) +
                                       B[13] * Convert.ToDouble(ogC[12]) +
                                       B[14] * Convert.ToDouble(ogC[13]) +
                                       B[15] * Convert.ToDouble(ogC[14]))))) * 100;
                }

                #endregion

                var sonListem = tumKisiler.Where(a => a.No != no && a.Label != 1).OrderByDescending(a => a.Puan).Take(10).ToList();

                dataGridView1.DataSource = digerList;
                dataGridView2.DataSource = egitimSeti;
                dataGridView3.DataSource = dataGridView3.DataSource = testSeti.OrderByDescending(a => a.Label).ToList();
                dataGridView4.DataSource = sonListem;

                label6.Text = sonListem.Count.ToString();
                textBox1.Text = null;
                textBox2.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı...!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection kisiler = new AutoCompleteStringCollection();
            foreach (var item in context.VW_Ogrenci_Network.ToList())
            {
                kisiler.Add(item.AdSoyad);
            }
            textBox2.AutoCompleteCustomSource = kisiler;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        void Temizle()
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView4.DataSource = null;
            textBox1.Text = null;
            textBox2.Text = null;
        }
    }
}
