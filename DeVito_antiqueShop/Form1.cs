using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace DeVito_antiqueShop
{
    public partial class Form1 : Form
    {
        // create list
        List<Soap> inventory = new List<Soap> ();
        int currentIndex = 0;

        // second list for cart
        List<Soap> bag = new List<Soap> ();

        decimal subtotal = 0;




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // adding inventory to list
            inventory.Add(new Soap("Lightfoot’s Pure Pine", 10, 19.95M, Image.FromFile("lightfoots.jpg")));
            inventory.Add(new Soap("Tres Chic", 8.5M, 24.95M, Image.FromFile("treschic.jpg")));
            inventory.Add(new Soap("Scottie Dog", 6.5M, 24.95M, Image.FromFile("scottie.jpg")));
            inventory.Add(new Soap("Piglets", 15, 29.95M, Image.FromFile("pigs.jpg")));
            inventory.Add(new Soap("Robin Eggs", 15, 29.95M, Image.FromFile("robin.jpg")));
            inventory.Add(new Soap("Chicks", 14, 19.95M, Image.FromFile("chicks.jpg")));
            inventory.Add(new Soap("Two Sheep", 12, 24.95M, Image.FromFile("sheep.jpg")));
            inventory.Add(new Soap("Ivory Bunnies", 8.5M, 24.95M, Image.FromFile("bunnies.jpg")));
            inventory.Add(new Soap("Dachshund", 6.5M, 24.95M, Image.FromFile("dachshund.jpg")));
            inventory.Add(new Soap("Happy Birthday", 12, 10.95M, Image.FromFile("birthday.jpg")));

            updateControls();
        }

        
        
        private void updateControls()
        {
            pictureBox1.Image = inventory[currentIndex].Photo;
            lblSoapName.Text = inventory[currentIndex].SoapName;
            lblSoapWeight.Text = inventory[currentIndex].SoapWeight + " Oz";
            lblSoapPrice.Text = "$ " + inventory[currentIndex].SoapPrice;
        



        }

        
        


        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // add limit to next button and update controls
            try
            {
                currentIndex++;
                updateControls();

            }
            catch (ArgumentOutOfRangeException)
            { 
                MessageBox.Show("You've reached the last item.");
                currentIndex--;
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // limit to back button
            try
            {
                currentIndex--;
                updateControls();

            }
            catch (ArgumentOutOfRangeException)
            { 
                MessageBox.Show("You've reached the last item.");
                currentIndex++;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bag.Add(inventory[currentIndex]);

            //add item and price to bag
            listCart.Items.Add(inventory[currentIndex].SoapName + " - "
                            + inventory[currentIndex].SoapPrice.ToString("C"));

            //add price to subtotal
            subtotal += inventory[currentIndex].SoapPrice;

            lblTotalPrice.Text = subtotal.ToString("C");
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (subtotal > 0)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.Show();
            }
            else
                MessageBox.Show("You must select at least one item to checkout");

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            //run if else to remove selected item from bag 
            if (listCart.SelectedIndex != -1)
            {
                subtotal -= bag[listCart.SelectedIndex].SoapPrice; //decrease subtotal

                //remove from list

                bag.RemoveAt(listCart.SelectedIndex);

                lblTotalPrice.Text = subtotal.ToString("C");

                //remove from list box

                listCart.Items.RemoveAt(listCart.SelectedIndex);


            }
            else
                MessageBox.Show("Select an item to remove.");


        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e, frmAbout frm)
        {
            frm.Show();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.Show();
        }

        private void lblSubTtl_Click(object sender, EventArgs e)
        {

        }

        private void listCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //Heading
            Font bigFont = new Font(lblTitle.Font.FontFamily, 24);

            Point headerpt = new Point(250, 50);

            e.Graphics.DrawString(lblTitle.Text, bigFont, Brushes.DarkGoldenrod, headerpt);

            //Pictures
            Font smallFont = new Font("Times New Roman", 12);

            //Make a list to hold print points
            List<Point> printpoints = new List<Point>();

            //first row of pics
            printpoints.Add(new Point(50, 150));
            printpoints.Add(new Point(300, 150));
            printpoints.Add(new Point(550, 150));

            //second row of pics
            printpoints.Add(new Point(50, 350));
            printpoints.Add(new Point(300, 350));
            printpoints.Add(new Point(550, 350));

            //third row of pics
            printpoints.Add(new Point(50, 550));
            printpoints.Add(new Point(300, 550));
            printpoints.Add(new Point(550, 550));

            for (int i = 0; i < bag.Count && i < printpoints.Count; i++)
            {
                //resize picture
                Bitmap resizedImage = new Bitmap(bag[i].Photo, 200, 150);
                e.Graphics.DrawImage(resizedImage, printpoints[i]);
                e.Graphics.DrawString(bag[i].SoapName + " - " + bag[i].SoapPrice.ToString("C"),
                                      smallFont,
                                      Brushes.Black,
                                      printpoints[i].X,        //x
                                      printpoints[i].Y + 160); //y

            }//end loop

            //Summary 
            Point summaryPoint = new Point(50, 800);

            e.Graphics.DrawString("Customer subtotal: " + subtotal.ToString("C"),
                                   smallFont,
                                   Brushes.Black,
                                   summaryPoint);

            summaryPoint.Y += 20; //advance the "Y" cursor

            e.Graphics.DrawString("Estimated Tax: " + (subtotal * .1M).ToString("C"),
                                   smallFont,
                                   Brushes.Black,
                                   summaryPoint);

            summaryPoint.Y += 20; //advance the "Y" cursor

            e.Graphics.DrawString("Customer Total: " + (subtotal * 1.1M).ToString("C"),
                                   smallFont,
                                   Brushes.Black,
                                   summaryPoint);

            summaryPoint.Y += 20; //advance the "Y" cursor

            e.Graphics.DrawString("Thank you for shopping at Modern Luxe! ",
                                   smallFont,
                                   Brushes.Black,
                                   summaryPoint);


        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            if (listCart.Items.Count > 0)
            {
                bag.Clear();
                listCart.Items.Clear();
                subtotal = 0;
                lblTotalPrice.Text = subtotal.ToString("C");
                updateControls();
            }
            else
                MessageBox.Show("No items to clear from cart.");
            
        }
    }
}
