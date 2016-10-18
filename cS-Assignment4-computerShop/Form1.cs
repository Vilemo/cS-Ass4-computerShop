using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cS_Assignment4_computerShop
{
    public partial class Form1 : Form
    {
        int MacBookNo = 0; //counter for how many MacBook computers
        int DellNo = 0;
        int HPNo = 0;
        int AsusNo = 0;
        int IBMNo = 0;
        int objNo = 0; //counter for how many objects
        string cType; //comboBox value for adding part
        bool cTypesUpdate = false; //switch off the comboBox for Updates (will be switch on after adding is done)
        ClassComputers[] objName = new ClassComputers[10];

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        public void display(int objNo)
        {
            //lbxNo.Items.Add(objNo);
            //lbxType.Items.Add(cType);
            //lbxBrand.Items.Add(tbxBrand.Text);
            //lbxPrice.Items.Add(tbxPrice.Text);
            //lbxMB.Items.Add(tbxMB.Text);
            //lbxCPU.Items.Add(tbxCPU.Text);
            //lbxSC.Items.Add(tbxSC.Text);
            //lbxGC.Items.Add(tbxGC.Text);
            //lbxNC.Items.Add(tbxNC.Text);
            //lbxHDD.Items.Add(tbxHDD.Text);
            //lbxM.Items.Add(tbxMonitor.Text);
            lbxNo.Items.Add(objNo);
            lbxType.Items.Add(cType);
            lbxBrand.Items.Add(tbxBrand.Text);
            lbxPrice.Items.Add(tbxPrice.Text);
            lbxMB.Items.Add(objName[objNo - 1].MB.ToString()); //-1 because objNo++ before calling display()
            lbxCPU.Items.Add(objName[objNo - 1].CPU.ToString());
            lbxSC.Items.Add(objName[objNo - 1].sCard.ToString());
            lbxGC.Items.Add(objName[objNo - 1].vCard.ToString());
            lbxNC.Items.Add(objName[objNo - 1].nCard.ToString());
            lbxHDD.Items.Add(objName[objNo - 1].HDD.ToString());
            lbxM.Items.Add(objName[objNo - 1].Monitor.ToString());

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string cBrand = tbxBrand.Text;
                double cPrice = Convert.ToDouble(tbxPrice.Text);
                string cMB = tbxMB.Text;
                string cCPU = tbxCPU.Text;
                string cSC = tbxSC.Text;
                string cGC = tbxGC.Text;
                string cNC = tbxNC.Text;
                string cHDD = tbxHDD.Text;
                string cM = tbxMonitor.Text;
                if (cBrand == "" || cPrice == 0 || cMB == "" || cCPU == "" || cSC == "" || cGC == "" || cNC == "" || cHDD == "" || cM == "")
                    MessageBox.Show("All fields are required!");
                else
                {
                    cType = cbxCType.GetItemText(cbxCType.SelectedItem); //gets the type of the computer
                    if (cType == "") MessageBox.Show("Choose the computer type");
                    else
                    {
                        if (cType == "MacBook")
                        {
                            ClassMacBook cObj = new ClassMacBook(cMB, cCPU, cSC, cGC, cNC, cHDD, cM, cBrand, cPrice);
                            MessageBox.Show(cObj.PrintInfo().ToString()); //show PrintInfo method from class
                            objName[objNo] = cObj; //save in object array
                            MacBookNo += 1;
                        }
                        else if (cType == "Dell")
                        {
                            ClassDell cObj = new ClassDell(cMB, cCPU, cSC, cGC, cNC, cHDD, cM, cBrand, cPrice);
                            MessageBox.Show(cObj.PrintInfo().ToString());
                            objName[objNo] = cObj;
                            DellNo += 1;
                        }
                        else if (cType == "HP")
                        {
                            ClassHP cObj = new ClassHP(cMB, cCPU, cSC, cGC, cNC, cHDD, cM, cBrand, cPrice);
                            MessageBox.Show(cObj.PrintInfo().ToString());
                            objName[objNo] = cObj;
                            HPNo += 1;
                        } 
                        else if (cType == "Asus")
                        {
                            ClassAsus cObj = new ClassAsus(cMB, cCPU, cSC, cGC, cNC, cHDD, cM, cBrand, cPrice);
                            MessageBox.Show(cObj.PrintInfo().ToString());
                            objName[objNo] = cObj;
                            AsusNo += 1;
                        } 
                        else 
                        {
                            ClassIBM cObj = new ClassIBM(cMB, cCPU, cSC, cGC, cNC, cHDD, cM, cBrand, cPrice);
                            MessageBox.Show(cObj.PrintInfo().ToString());
                            objName[objNo] = cObj;
                            IBMNo += 1;
                        }
                        objNo++;
                        display(objNo);
                        checkCompNo(objNo);
                    }
                }//end else
            }//end try
            catch (FormatException fEx)
            {
                MessageBox.Show("Wrong value!" + Environment.NewLine + fEx.Message);
            }
        }
        public void checkCompNo(int objNo) //removes comp types from comboBox if they were used 2x
        {
            if (objNo == 10)
            {
                cbxCType.Items.Clear();
                for (int i = 0; i < lbxBrand.Items.Count; i++) //fill comboBox with new values: "comp type + brand"
                {
                    cbxCType.Items.Add((i+1).ToString() + ". " + lbxType.Items[i] + " " + lbxBrand.Items[i]);
                }
                btnAdd.Enabled = false; //lock Add button
                btnUpdate.Enabled = true; //unlock Update button
                cTypesUpdate = true; //the comboBox with update values is on
                clearTB(); //clear all textBoxes
            }
            else
            {
                if (MacBookNo == 2) cbxCType.Items.Remove("MacBook");
                if (DellNo == 2) cbxCType.Items.Remove("Dell");
                if (HPNo == 2) cbxCType.Items.Remove("HP");
                if (AsusNo == 2) cbxCType.Items.Remove("Asus");
                if (IBMNo == 2) cbxCType.Items.Remove("IBM");
            }
        }
        private void cbxCType_SelectedIndexChanged(object sender, EventArgs e) //fills textBoxes with saved values for choosen computer type
        {
            if (cTypesUpdate) //if the comboBox for updates is on
            {
                int cbxIndex = cbxCType.SelectedIndex; //now it's my index for listBoxes
                if (cbxIndex != -1)
                {
                    tbxBrand.Text = lbxBrand.Items[cbxIndex].ToString();
                    tbxPrice.Text = lbxPrice.Items[cbxIndex].ToString();
                    tbxMB.Text = lbxMB.Items[cbxIndex].ToString();
                    tbxCPU.Text = lbxCPU.Items[cbxIndex].ToString();
                    tbxSC.Text = lbxSC.Items[cbxIndex].ToString();
                    tbxGC.Text = lbxGC.Items[cbxIndex].ToString();
                    tbxNC.Text = lbxNC.Items[cbxIndex].ToString();
                    tbxHDD.Text = lbxHDD.Items[cbxIndex].ToString();
                    tbxMonitor.Text = lbxM.Items[cbxIndex].ToString();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int cbxIndex = cbxCType.SelectedIndex; //now it's my index for array :)
            if (cbxIndex == -1) MessageBox.Show("Choose the computer type");
            else
            {
                    string compTypeUpdate = lbxType.Items[cbxIndex].ToString();
                    try
                    {
                        string cBrand = tbxBrand.Text;
                        double cPrice = Convert.ToDouble(tbxPrice.Text);
                        string cMB = tbxMB.Text;
                        string cCPU = tbxCPU.Text;
                        string cSC = tbxSC.Text;
                        string cGC = tbxGC.Text;
                        string cNC = tbxNC.Text;
                        string cHDD = tbxHDD.Text;
                        string cM = tbxMonitor.Text;
                        if (cBrand == "" || cPrice == 0 || cMB == "" || cCPU == "" || cSC == "" || cGC == "" || cNC == "" || cHDD == "" || cM == "")
                            MessageBox.Show("All fields are required!");
                        else
                        {
                            if (compTypeUpdate == "MacBook")
                            {
                                ClassMacBook cObj = new ClassMacBook(cMB, cCPU, cSC, cGC, cNC, cHDD, cM, cBrand, cPrice);
                                MessageBox.Show(cObj.PrintInfo().ToString());
                                objName[cbxIndex] = cObj;
                            }
                            else if (cType == "Dell")
                            {
                                ClassDell cObj = new ClassDell(cMB, cCPU, cSC, cGC, cNC, cHDD, cM, cBrand, cPrice);
                                MessageBox.Show(cObj.PrintInfo().ToString());
                                objName[cbxIndex] = cObj;
                            }
                            else if (cType == "HP")
                            {
                                ClassHP cObj = new ClassHP(cMB, cCPU, cSC, cGC, cNC, cHDD, cM, cBrand, cPrice);
                                MessageBox.Show(cObj.PrintInfo().ToString());
                                objName[cbxIndex] = cObj;
                            }
                            else if (cType == "Asus")
                            {
                                ClassAsus cObj = new ClassAsus(cMB, cCPU, cSC, cGC, cNC, cHDD, cM, cBrand, cPrice);
                                MessageBox.Show(cObj.PrintInfo().ToString());
                                objName[cbxIndex] = cObj;
                            }
                            else
                            {
                                ClassIBM cObj = new ClassIBM(cMB, cCPU, cSC, cGC, cNC, cHDD, cM, cBrand, cPrice);
                                MessageBox.Show(cObj.PrintInfo().ToString());
                                objName[cbxIndex] = cObj;
                            }
                            displayUpdate(cbxIndex);
                        }
                    }
                    catch (FormatException fEx)
                    {
                        MessageBox.Show("Wrong value!" + Environment.NewLine + fEx.Message);
                    }
                }
        }
        public void displayUpdate(int index)
        {
            lbxBrand.Items.RemoveAt(index); //remove old value
            lbxBrand.Items.Insert(index, tbxBrand.Text); //insert new value
            lbxPrice.Items.RemoveAt(index);
            lbxPrice.Items.Insert(index, tbxPrice.Text);
            lbxMB.Items.RemoveAt(index);
            lbxMB.Items.Insert(index, tbxMB.Text);
            lbxCPU.Items.RemoveAt(index);
            lbxCPU.Items.Insert(index, tbxCPU.Text);
            lbxSC.Items.RemoveAt(index);
            lbxSC.Items.Insert(index, tbxSC.Text);
            lbxGC.Items.RemoveAt(index);
            lbxGC.Items.Insert(index, tbxGC.Text);
            lbxNC.Items.RemoveAt(index);
            lbxNC.Items.Insert(index, tbxNC.Text);
            lbxHDD.Items.RemoveAt(index);
            lbxHDD.Items.Insert(index, tbxHDD.Text);
            lbxM.Items.RemoveAt(index);
            lbxM.Items.Insert(index, tbxMonitor.Text);

            //lbxMB.Items.Add(objName[objNo - 1].MB.ToString()); //-1 because objNo++ before calling display()

        }
        public void clearTB() //clear all textBoxes
        {
            tbxBrand.Clear();
            tbxPrice.Text = "0.0";
            tbxMB.Clear();
            tbxCPU.Clear();
            tbxSC.Clear();
            tbxGC.Clear();
            tbxNC.Clear();
            tbxHDD.Clear();
            tbxMonitor.Clear();
            cbxCType.SelectedIndex = -1;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearTB(); //clear all textBoxes
        }
        private void btnFillD_Click(object sender, EventArgs e)
        {
            string[] defCType = new string[] { "MacBook", "MacBook", "Dell", "Dell", "HP", "HP", "Asus", "Asus", "IBM", "IBM"};
            string[] defBrand = new string[] { "Pro", "Air", "Licore 15", "Norah", "LEW 15'", "Nero", "777", "888", "STG 3", "STG 5.1" };
            string[] defPrice = new string[] { "1111.11", "2222.22", "333.33", "444.44", "5555.55", "666.66", "777.77", "888.88", "999.99", "1000.00" };
            string[] defMB = new string[] { "abc122", "abc331", "bbb545", "bbb111", "ccc111", "ccc333", "ddd999", "ddd222", "eee000", "eee555" };
            string[] defCPU = new string[] { "abc122", "abc331", "bbb545", "bbb111", "ccc111", "ccc333", "ddd999", "ddd222", "eee000", "eee555" };
            string[] defSC = new string[] { "abc122", "abc331", "bbb545", "bbb111", "ccc111", "ccc333", "ddd999", "ddd222", "eee000", "eee555" };
            string[] defGC = new string[] { "abc122", "abc331", "bbb545", "bbb111", "ccc111", "ccc333", "ddd999", "ddd222", "eee000", "eee555" };
            string[] defNC = new string[] { "abc122", "abc331", "bbb545", "bbb111", "ccc111", "ccc333", "ddd999", "ddd222", "eee000", "eee555" };
            string[] defHDD = new string[] { "abc122", "abc331", "bbb545", "bbb111", "ccc111", "ccc333", "ddd999", "ddd222", "eee000", "eee555" };
            string[] defMonitor = new string[] { "abc122", "abc331", "bbb545", "bbb111", "ccc111", "ccc333", "ddd999", "ddd222", "eee000", "eee555" };

            clearLB(); //clears all listBoxes

            for (int i = 0; i < 10; i++)
            {
                lbxNo.Items.Add((i+1).ToString());
                lbxType.Items.Add(defCType[i]);
                lbxBrand.Items.Add(defBrand[i]);
                lbxPrice.Items.Add(defPrice[i]);
                lbxMB.Items.Add(defMB[i]);
                lbxCPU.Items.Add(defCPU[i]);
                lbxSC.Items.Add(defSC[i]);
                lbxGC.Items.Add(defGC[i]);
                lbxNC.Items.Add(defNC[i]);
                lbxHDD.Items.Add(defHDD[i]);
                lbxM.Items.Add(defMonitor[i]);
                checkCompNo(10); //sets environment for update now
            }
        }
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            clearLB(); //clears all listBoxes
            btnAdd.Enabled = true; //unlock Add button
            btnUpdate.Enabled = false; //lock Update button
            cTypesUpdate = false; //the comboBox with update values is off
            clearTB(); //clear all textBoxes
            objNo = 0; //0 objects
            cbxCType.Items.Clear();//clear comboBox
            cbxCType.Items.Add("MacBook");//fill comboBox with standard compTypes
            cbxCType.Items.Add("Dell");
            cbxCType.Items.Add("HP");
            cbxCType.Items.Add("Asus");
            cbxCType.Items.Add("IBM");
        }
        public void clearLB() //clear all listBoxes
        {
            lbxNo.Items.Clear();
            lbxType.Items.Clear();
            lbxBrand.Items.Clear();
            lbxPrice.Items.Clear();
            lbxMB.Items.Clear();
            lbxCPU.Items.Clear();
            lbxSC.Items.Clear();
            lbxGC.Items.Clear();
            lbxNC.Items.Clear();
            lbxHDD.Items.Clear();
            lbxM.Items.Clear();
        }
    }
}
