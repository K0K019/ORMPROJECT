using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
   
      
        public partial class Form1 : Form
        {
        public Form1()
        {
            InitializeComponent();
        }

            DishController dishController = new DishController();
            DishTypeController dishTypeController = new DishTypeController();

          
            private void Form1_Load(object sender, EventArgs e)
            {
                var types = dishTypeController.GetAllDishes();
                comboBox1.DataSource = types;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "DishTypeId";

                btnSelectAll_Click(sender, e);
            }

            private void LoadRecord(Dish dish)
            {
                textBox1.BackColor = Color.White;
                textBox1.Text = dish.DishId.ToString();
                textBox2.Text = dish.Name;
                textBox3.Text = dish.Description;
                textBox4.Text = dish.Price.ToString("F2");
                textBox5.Text = dish.WeightGrams.ToString();
                comboBox1.Text = dish.DishType.TypeName;
            }

            private void ClearScreen()
            {
                textBox1.BackColor = Color.White;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.SelectedIndex = -1;
            }

            private void btnAdd_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Моля въведете име на ястието!");
                    textBox2.Focus();
                    return;
                }

                Dish dish = new Dish
                {
                    Name = textBox2.Text,
                    Description = textBox3.Text,
                    Price = decimal.Parse(textBox4.Text),
                    WeightGrams = int.Parse(textBox5.Text),
                    DishTypeId = (int)comboBox1.SelectedValue
                };

                dishController.Create(dish);
                MessageBox.Show("Ястието е добавено успешно.");
                ClearScreen();
                btnSelectAll_Click(sender, e);
            }

            private void btnSelectAll_Click(object sender, EventArgs e)
            {
                listBox1.Items.Clear();
                var dishes = dishController.GetAll();
                foreach (var dish in dishes)
                {
                    listBox1.Items.Add($"{dish.DishId}. {dish.Name} - {dish.Price:C} - {dish.DishType.TypeName}");
                }
            }

            private void btnFind_Click(object sender, EventArgs e)
            {
                if (!int.TryParse(textBox1.Text, out int id))
                {
                    MessageBox.Show("Невалидно ID!");
                    textBox1.BackColor = Color.Red;
                    return;
                }

                var dish = dishController.Get(id);
                if (dish == null)
                {
                    MessageBox.Show("Няма такова ястие!");
                    return;
                }

                LoadRecord(dish);
            }

            private void btnUpdate_Click(object sender, EventArgs e)
            {
                if (!int.TryParse(textBox1.Text, out int id))
                {
                    MessageBox.Show("Невалидно ID!");
                    return;
                }

                Dish updatedDish = new Dish
                {
                    Name = textBox2.Text,
                    Description = textBox3.Text,
                    Price = decimal.Parse(textBox4.Text),
                    WeightGrams = int.Parse(textBox5.Text),
                    DishTypeId = (int)comboBox1.SelectedValue
                };

                dishController.Update(id, updatedDish);
                MessageBox.Show("Ястието е обновено успешно.");
                btnSelectAll_Click(sender, e);
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                if (!int.TryParse(textBox1.Text, out int id))
                {
                    MessageBox.Show("Невалидно ID!");
                    return;
                }

                var dish = dishController.Get(id);
                if (dish == null)
                {
                    MessageBox.Show("Няма такова ястие!");
                    return;
                }

                var result = MessageBox.Show($"Наистина ли искате да изтриете {dish.Name}?", "Потвърждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dishController.Delete(id);
                    btnSelectAll_Click(sender, e);
                }
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    }
