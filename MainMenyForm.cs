using demo_training_StockProKSV.StockProDB_demoDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace demo_training_StockProKSV
{
    public partial class MainMenuForm : Form
    {
        ListViewItem LastSelectedItem;
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Товары". При необходимости она может быть перемещена или удалена.
            this.товарыTableAdapter.Fill(this.stockProDB_demoDataSet.Товары);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Расходы". При необходимости она может быть перемещена или удалена.
            this.расходыTableAdapter.Fill(this.stockProDB_demoDataSet.Расходы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Поставки". При необходимости она может быть перемещена или удалена.
            this.поставкиTableAdapter.Fill(this.stockProDB_demoDataSet.Поставки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.stockProDB_demoDataSet.Пользователи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Минимальные_Уровни_Товаров". При необходимости она может быть перемещена или удалена.
            this.минимальные_Уровни_ТоваровTableAdapter.Fill(this.stockProDB_demoDataSet.Минимальные_Уровни_Товаров);
            FillProdList(); 
            FillFilterProdList();
        }

        void FillProdList()
        {
            listView1.Items.Clear();
            foreach (DataRow row in stockProDB_demoDataSet.Товары.Rows)
            {
                //DataRow TempRow;
                string[] items = new string[6];
                items[1] = row[1].ToString();
                items[2] = row[2].ToString();
                items[3] = row[3].ToString();
                DateTime date = (DateTime)row[4]; // Преобразование объекта в тип DateTime
                items[4] = date.ToString("yyyy-MM-dd"); // Форматирование даты в строку без времени
                items[5] = row[5].ToString();
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = row[0].ToString();
                listViewItem.SubItems.AddRange(items);
                listView1.Items.Add(listViewItem);
            }
            CountLabel.Text = $"Количество чего-то {listView1.Items.Count} из {stockProDB_demoDataSet.Товары.Count}";
        }
        //вывод для фильтрации
        void FillFilterProdList()
        {
            listViewFilter.Items.Clear();
            foreach (DataRow row in stockProDB_demoDataSet.Товары.Rows)
            {
                //DataRow TempRow;
                string[] items = new string[6];
                items[1] = row[1].ToString();
                items[2] = row[2].ToString();
                items[3] = row[3].ToString();
                DateTime date = (DateTime)row[4]; // Преобразование объекта в тип DateTime
                items[4] = date.ToString("yyyy-MM-dd"); // Форматирование даты в строку без времени
                items[5] = row[5].ToString();
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = row[0].ToString();
                listViewItem.SubItems.AddRange(items);
                listViewFilter.Items.Add(listViewItem);
            }
            CountLabel.Text = $"Количество чего-то {listViewFilter.Items.Count} из {stockProDB_demoDataSet.Товары.Count}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewProduct addNewProduct  = new AddNewProduct();

            addNewProduct.ShowDialog();
            if (addNewProduct.DialogResult == DialogResult.OK)
            {
                FillProdList();
                FillFilterProdList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow[] RowsProduct;
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                DialogResult reslt = MessageBox.Show("Вы действительно хотите удалить выделенные объекты? ", "Предупреждение!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (reslt == DialogResult.OK)
                {
                    RowsProduct = stockProDB_demoDataSet.Товары.Select("Товар_ID = '" + item.Text + "'");
                    товарыTableAdapter.Delete(Convert.ToInt16(RowsProduct[0][0]), Convert.ToString(RowsProduct[0][1]), Convert.ToInt16(RowsProduct[0][2]), decimal.Parse(RowsProduct[0][3].ToString()), (DateTime)RowsProduct[0][4]);

                    LastSelectedItem.Remove();
                    MessageBox.Show("Успешное удаление!", "Процесс удаления: 100%", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CountLabel.Text = $"Количество чего-то {listViewFilter.Items.Count} из {stockProDB_demoDataSet.Товары.Count}";
                }
            }
            this.товарыTableAdapter.Fill(stockProDB_demoDataSet.Товары);
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
                LastSelectedItem = e.Item;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           listView1.Items.Clear();
            listViewFilter.Items.Clear();
            FillProdList();
            FillFilterProdList();
            CountLabel.Text = $"Количество чего-то {listViewFilter.Items.Count} из {stockProDB_demoDataSet.Товары.Count}";
        }
    }
}
