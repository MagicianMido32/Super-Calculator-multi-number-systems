using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS_ClassLibraryTester;

namespace WindowsFormsApplication1
{

    public partial class MainF : Form
    {

        #region pilot
        public TextBox target; //the sellected textbox 
        string answer;  //result
        public int trgtbase; //the sellected textbox base
        public double op1, op2; //operators
        public string opera = "";//operation
        public MainF()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Deg.Checked = true;
            #region btns
            int xx = 40; int intiall = 40;//the x and y values to begin with , the upper left point
            int yy = 192;
            for (int i = 0; i < 16; i++)//adding number buttons
            {
                BoosterButton x = new BoosterButton();
                x.Size = new System.Drawing.Size(56, 40);
                if (i % 4 == 0) { xx = intiall; yy += 63; }
                x.Location = new System.Drawing.Point(xx, yy);
                xx += 64;
                x.Text = (i < 10) ? i.ToString() : convert(i.ToString(), 10, 16);
                Bform.Controls.Add(x);
                x.Click += delegate { target.Text += x.Text; };
            }
            #endregion
            #region dlgts
            //adding subs to buttons
            //if the user wrote a number then clicked an operator then wrote a number then clicked an operator again
            //solve the first expression
            //and set the value of the first operand to the result of the first Expression 
            //(if !(opera=="") means has the user clicked and operator before ? and didn't click solve
            //operators
            adbtn.Click += delegate { if (!(opera == "")) { solv(); } operat("+"); };
            //min special sub
            dvbtn.Click += delegate { if (!(opera == "")) { solv(); } operat("/"); };
            multbn.Click += delegate { if (!(opera == "")) { solv(); } operat("*"); };
            modbtn.Click += delegate { if (!(opera == "")) { solv(); } operat("MOD"); };
            Andbtn.Click += delegate { if (!(opera == "")) { solv(); } operat("AND"); };
            Orbtn.Click += delegate { if (!(opera == "")) { solv(); } operat("OR"); };
            Norbtn.Click += delegate { if (!(opera == "")) { solv(); } operat("NOR"); };
            Nandbtn.Click += delegate { if (!(opera == "")) { solv(); } operat("NAND"); };
            Xorbtn.Click += delegate { if (!(opera == "")) { solv(); } operat("XOR"); };
            Xnorbtn.Click += delegate { if (!(opera == "")) { solv(); } operat("XNOR"); };
            rshbtn.Click += delegate { if (!(opera == "")) { solv(); } operat(">>"); };
            lshbtn.Click += delegate { if (!(opera == "")) { solv(); } operat("<<"); };
            pwrbtn.Click += delegate { if (!(opera == "")) { solv(); } operat("^"); };
            nPr.Click += delegate { if (!(opera == "")) { solv(); } operat("nPr"); };
            nCr.Click += delegate { if (!(opera == "")) { solv(); } operat("nCr"); };
            nRoot.Click += delegate { if (!(opera == "")) { solv(); } operat("nRoot"); };
            XlogN.Click += delegate { if (!(opera == "")) { solv(); } operat("XlogN"); };
            //trigonometric
            //Is unary operators
            sin.Click += delegate { trigsolv("sin"); };
            cos.Click += delegate { trigsolv("cos"); };
            tan.Click += delegate { trigsolv("tan"); };
            cot.Click += delegate { trigsolv("cot"); };
            sec.Click += delegate { trigsolv("sec"); };
            csc.Click += delegate { trigsolv("csc"); };
            arcsin.Click += delegate { trigsolv("arcsin"); };
            arcos.Click += delegate { trigsolv("arcos"); };
            arctan.Click += delegate { trigsolv("arctan"); };
            arcot.Click += delegate { trigsolv("arcot"); };
            arcsec.Click += delegate { trigsolv("arcsec"); };
            arcsc.Click += delegate { trigsolv("arcsc"); };
            Sinh.Click += delegate { trigsolv("sinh"); };
            Tanh.Click += delegate { trigsolv("tanh"); };
            cosh.Click += delegate { trigsolv("cosh"); };
            #endregion
            //initializing view
            rddec.Checked = true;
            target = dectx;
            trgtbase = 10;
            hdsho(9);
        }


        #endregion
        #region math
        //convert between  bases
        public string convert(string num, int frmbase, int tobase)
        {
            /*
             *
             a number is taken , If it's an integer
             * then It's converted normally
             * If It's negative , then we remove the negative sign ,convert the number , then add the sign again
             * I'f It's fraction , then we split it into two integer part , convert each part alon 
             * then combine them
             * as the .Net Framework can't convert fractions between different bases
             * 
             * the conversion process is as follows 
             * from hex to binary
             * 1.the hex value is converted to decimal value
             * 2.the decimal value is converted to binary
             * for fractions complements are used
             * the following Algorithm (inventted by me) B = A * r1^2/r2^n 
             * where B is the result , A is the number we want to convert , r1 is A's radix(base) , r2 is B's radix
             * the number is converted to decimal , 
             * then result = Number * Tobase ^n / It's Base ^n where n is the number of degits
             * parts are then combined
             */

            try
            {
                if (num == "" || num == "0." || num == "-") return ""; //checking for Errors
                bool Isminus = false;//Is the number negative?
                string clcr = "";
                num = num.Replace(" ", "");
                //If the number is negative , remove the - sign , convert it , then add the sign again
                //As the .Net Framework can't convert negative numbers
                if (num[0] == '-') { num = num.Replace("-", ""); Isminus = true; }
                //initializing bases
                int[] x = { 2, 8, 10, 16 };


                string goodpart = "";//integer part
                if (num.Contains('.'))
                {
                    goodpart = num.Substring(0, num.IndexOf('.'));//get the integer part
                }
                else { goodpart = num; }

                int decimalval = Convert.ToInt32(goodpart, frmbase);
                string convertgoodpart = Convert.ToString(decimalval, tobase);
                clcr += convertgoodpart.ToUpper();
                ///////////////////////////
                //fractions
                if (num.Contains('.'))
                {

                    string fractpart = num.Substring(num.IndexOf('.') + 1);
                    //keeping precision to 8 digits
                    if (fractpart.Length >= 7) { fractpart = fractpart.Substring(0, 7); }//if the fraction part is more than 8 digits , trim it to exactly 8 digits
                    else
                    { //else if fraction part is less than 8 digits complete it to 8 digits
                        fractpart += new string('0', (7 - fractpart.Length));///problem
                    }
                    //this to perform the radix algorithm more accurately 
                    int DecimalFracion = Convert.ToInt32(fractpart, frmbase);
                    double decrest = DecimalFracion * Math.Pow((double)tobase, fractpart.Length) / Math.Pow((double)frmbase, fractpart.Length);
                    //  string pscl = decrest.ToString().Replace(".", "");
                    //  if (pscl.Length > 8) pscl=pscl.Substring(0,8);
                    // int pascal = Convert.ToInt32(pscl);
                    string tbaseresult = Convert.ToString(/*pascal*/(int)decrest, tobase).Replace("-", "");//we take the integer part from it because fraction aren't necessary 
                    tbaseresult = tbaseresult.TrimEnd('0');//trimming the zeros we added    
                    if (!(tbaseresult == "0"))
                    {
                        clcr += "." + tbaseresult.ToUpper();
                    }
                }

                if (clcr[0] == '.') { clcr = "0" + clcr; } //so as not to get something like .2 , but 0.2
                if (Isminus) { clcr = "-" + clcr; }
                return clcr;
            }
            catch { bintx.Text = ""; octx.Text = ""; dectx.Text = ""; hextx.Text = ""; return ""; }//When error occur

        }
        //-----------------------------------------------------------------------------------------
        public void operat(string x)
        { //when user click an operation button
            //the first operand will be the value of the textbox op1
            //the operation is passed to this function via delegate 
            //then initialize the program to recieve the second operand op2 and solve 

            if (!(opera == "") || target.Text == "" || target.Text == "-" || target.Text.Last() == '.') return;

            op1 = Double.Parse(convert(target.Text, trgtbase, 10));//the first operand
            opera = x;//the operation
            if (svtxtbx.Text == "") svtxtbx.Text += target.Text; //draft
            svtxtbx.Text += " " + x;
            target.Text = "";
        }
        #region solvers
        //-----------------------------------------------------------------------------------------
        public void solv()
        {
            try
            {
                if ((opera == "") || target.Text == "" || target.Text == "-" || target.Text.Last() == '.') return;//handling errors

                op2 = Double.Parse(convert(target.Text, trgtbase, 10));//the second operand is the value of textbox 
                //the second number enterd by user

                bool IsFrct = op1.ToString().Contains('.') || op2.ToString().Contains('.'); // are numbers fractions ?


                int[] slr = bitwise(op1.ToString(), op2.ToString()); //spliting numbers

                switch (opera)
                {
                    case "+":
                        target.Text = Cv((op1 + op2).ToString());
                        break;
                    case "-":
                        target.Text = (op1 - op2).ToString();
                        break;
                    case "/":
                        if (op2 == 0) { target.Text = ""; svtxtbx.Text = svtxtbx.Text.Replace(opera, ""); break; }
                        target.Text = Cv((Math.Round((op1 / op2), 8)).ToString());
                        break;
                    case "*":
                        target.Text = Cv((op1 * op2).ToString());
                        break;
                    case "^":
                        target.Text = Cv(Math.Pow(op1, op2).ToString());
                        break;
                    case "MOD":
                        target.Text = Cv((op1 % op2).ToString());
                        break;
                    case "OR":
                        target.Text = Cv((slr[0] | slr[1]).ToString()) + (IsFrct ? ("." + Cv((slr[2] | slr[3]).ToString())) : "");
                        break;
                    case "AND":
                        target.Text = Cv((slr[0] & slr[1]).ToString()) + (IsFrct ? ("." + Cv((slr[2] & slr[3]).ToString())) : "");
                        break;
                    //Not unary special sub
                    case "XOR":
                        target.Text = Cv((slr[0] ^ slr[1]).ToString()) + (IsFrct ? ("." + Cv((slr[2] ^ slr[3]).ToString())) : "");
                        break;
                    case "XNOR":
                        target.Text = Cv((~(slr[0] ^ slr[1])).ToString()) + (IsFrct ? ("." + Cv(((slr[2] ^ slr[3])).ToString())) : "");
                        break;
                    case "NAND":
                        target.Text = Cv((~(slr[0] & slr[1])).ToString()) + (IsFrct ? ("." + Cv(((slr[2] & slr[3])).ToString())) : "");
                        break;
                    case "NOR":
                        target.Text = Cv((~(slr[0] | slr[1])).ToString()) + (IsFrct ? ("." + Cv(((slr[2] | slr[3])).ToString())) : "");
                        break;
                    case ">>":
                        target.Text = Cv((slr[0] >> slr[1]).ToString()) + (IsFrct ? ("." + Cv((slr[2] >> slr[3]).ToString())) : "");
                        break;
                    case "<<":
                        target.Text = Cv((slr[0] << slr[1]).ToString()) + (IsFrct ? ("." + Cv((slr[2] << slr[3]).ToString())) : "");
                        break;
                    case "nPr":
                        if (op2 > op1) { target.Text = ""; svtxtbx.Text = svtxtbx.Text.Replace(opera, ""); break; }
                        target.Text = Cv((fact((int)op1) / fact((int)(op1 - op2))).ToString());
                        break;
                    case "nCr":
                        if (op2 > op1) { target.Text = ""; svtxtbx.Text = svtxtbx.Text.Replace(opera, ""); break; }
                        target.Text = Cv((fact((int)op1) * (fact((int)(op1 - op2)) / fact((int)op2))).ToString());
                        break;
                    case "nRoot":
                        target.Text = Cv((Math.Pow(op1, op2).ToString()));
                        break;
                    case "XlogN":
                        if (op1 == 0 || op2 == 0 || Math.Sign(op1) == -1 || Math.Sign(op2) == -1) { target.Text = ""; break; }
                        target.Text = Cv(Math.Log(op1, op2).ToString());
                        break;

                }
                //reinitializing to recieve first operand
                if (target.Text.Length >= 2 && target.Text[target.Text.Length - 1] == '0' && target.Text[target.Text.Length - 2] == '.')
                {
                    target.Text = target.Text.Replace(".0", "");
                }
                answer = target.Text;
                svtxtbx.Text = answer;
                op1 = op2;
                op2 = 0;
                opera = "";

            }
            catch { clear(); }
        }
        //-------------------------------------------------------------------------------
        void trigsolv(string operation)
        {
            //trigenometrics are unary operations
            //the user will enter a number
            //press the operation
            //the result will be calculated immediately inside the textbox
            if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
            try
            {
                double x = Convert.ToDouble(convert(target.Text, trgtbase, 10));
                if (Deg.Checked) { x = x * Math.PI / 180; } //Radian or Degrees ?
                switch (operation)
                {
                    case "sin":
                        x = Math.Sin(x);
                        break;
                    case "cos":
                        x = Math.Cos(x);
                        break;
                    case "tan":
                        x = Math.Tan(x);
                        break;
                    //--------------//
                    case "cot":
                        x = 1 / Math.Tan(x);
                        break;
                    case "sec":
                        x = 1 / Math.Cos(x);
                        break;
                    case "csc":
                        x = 1 / Math.Sin(x);
                        break;
                    //--------------//
                    case "arcsin":
                        x = Math.Atan(x / Math.Sqrt(-x * x + 1));
                        break;
                    case "arcos":
                        x = Math.Atan(-x / Math.Sqrt(-x * x + 1)) + 2 * Math.Atan(1);
                        break;
                    case "arctan":
                        x = Math.Atan(x);
                        break;
                    case "arcot":
                        x = 2 * Math.Atan(1) - Math.Atan(x);
                        break;
                    case "arcsec":
                        x = 2 * Math.Atan(1) - Math.Atan(Math.Sign(x) / Math.Sqrt(x * x - 1));
                        break;
                    case "arcsc":
                        x = Math.Atan(Math.Sign(x) / Math.Sqrt(x * x - 1));
                        break;
                    //--------------//
                    case "sinh":
                        x = Math.Sinh(x);
                        break;
                    case "cosh":
                        x = Math.Cosh(x);
                        break;
                    case "tanh":
                        x = Math.Tanh(x);
                        break;
                    //--------------//

                }
                if (rsltdg.Checked) { x = x * 180 / Math.PI; } //Show results in Degrees
                target.Text = Cv(x.ToString());
            }
            catch { bintx.Text = ""; octx.Text = ""; dectx.Text = ""; hextx.Text = ""; }
        }
        #endregion
        string Cv(string dect)//Back to it's base
        {
            return convert(dect, 10, trgtbase);
        }
        int[] bitwise(string one, string two)//Split string into two parts , support fractions
        {                                    //For bitwise operations
            //one [integer part ] [fraction part ]
            //two [integer part ] [fraction part ]

            string[] oo = new string[2];
            string[] tt = new string[2];
            if (one.Contains('.') && two.Contains('.'))
            {
                oo = one.Split('.');
                tt = two.Split('.');
            }

            else if (one.Contains('.'))
            {
                oo = one.Split('.');
                tt[0] = two;
                tt[1] = "0";
            }
            else if (two.Contains('.'))
            {
                tt = two.Split('.');
                oo[0] = one;
                oo[1] = "0";
            }
            else
            {
                oo[0] = one; tt[0] = two;
                oo[1] = "0"; tt[1] = "0";
            }
            //recombine the numbers again and send them back as an array
            return new int[] { Convert.ToInt32(oo[0]), Convert.ToInt32(tt[0]), Convert.ToInt32(oo[1]), Convert.ToInt32(tt[1]) };

        }
        #endregion
        #region controlwindow
        //Control box
        private void Aboutbuton_Click(object sender, EventArgs e)
        {
            new Form2().Show();

        }
        private void Minmizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
        #region radios
        //radio boxes
        private void Rad_CheckedChanged(object sender)
        {
            Deg.Checked = false;
        }

        private void Deg_CheckedChanged(object sender)
        {
            Rad.Checked = false;
        }
        private void rdbin_CheckedChanged(object sender)
        {
            rdoct.Checked = false;
            rddec.Checked = false;
            rdhx.Checked = false;
            target = bintx;
            trgtbase = 2;
            target.Focus();
            hdsho(1);
            if (!(opera == "")) { svtxtbx.Text += target.Text; } else { svtxtbx.Text = target.Text; }
        }

        private void rdoct_CheckedChanged(object sender)
        {
            rdbin.Checked = false;
            rddec.Checked = false;
            rdhx.Checked = false;
            target = octx;
            trgtbase = 8;
            target.Focus();
            hdsho(7);
            if (!(opera == "")) { svtxtbx.Text += target.Text; } else { svtxtbx.Text = target.Text; }
        }

        private void rddec_CheckedChanged(object sender)
        {
            rdbin.Checked = false;
            rdoct.Checked = false;
            rdhx.Checked = false;
            target = dectx;
            trgtbase = 10;
            target.Focus();
            hdsho(9);
            if (!(opera == "")) { svtxtbx.Text += target.Text; } else { svtxtbx.Text = target.Text; }
        }

        private void rdhx_CheckedChanged(object sender)
        {
            rdbin.Checked = false;
            rdoct.Checked = false;
            rddec.Checked = false;
            target = hextx;
            trgtbase = 16;
            target.Focus();
            hdsho(15);
            if (!(opera == "")) { svtxtbx.Text += target.Text; } else { svtxtbx.Text = target.Text; }

        }

        #endregion
        #region otherbuttons

        private void dtptn_Click(object sender, EventArgs e)
        {

            if (target.Text == "" || target.Text == "-") { target.Text += "0."; }
            else if (!target.Text.Contains(".") || target.Text.Last() == '-') { target.Text += "."; }
        }
        private void minbtn_Click(object sender, EventArgs e) //the negative button -
        {                                                 //used for both negation and subtraction

            if (target.Text == "") { target.Text = "-"; }
            else
            {
                if (!(opera == "")) { solv(); }
                operat("-");
            }
        }

        private void Delbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string hold = "";
                for (int i = 0; i < target.Text.Length - 1; i++)
                {
                    hold += target.Text[i];
                }
                target.Text = hold;
            }
            catch { }
        }
        private void NOTBtn_Click(object sender, EventArgs e) //the Negation operator NOT
        {
            try
            {
                //the number is converted to decimal
                //It's negation is computed via this Algorithm (invented by me)
                //nagation = -1 - number
                //then convert it back to It's base
                if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
                op1 = Convert.ToDouble(convert(target.Text, trgtbase, 10));
                double numer = -1 - op1;
                target.Text = Cv(numer.ToString());
            }
            catch { clear(); }
        }

        private void RadDeg_Click(object sender, EventArgs e) //radian to degrees
        {
            if (target.Text == "" || target.Text == "-" || target.Text == "0.") return;
            try
            {
                target.Text = Cv((Math.Round((Convert.ToDouble(convert(target.Text, trgtbase, 10)) * 180 / Math.PI), 8)).ToString());
            }
            catch { clear(); }
        }
        private void DegRad_Click(object sender, EventArgs e)//degrees to radians
        {
            if (target.Text == "" || target.Text == "-" || target.Text == "0.") return;
            try
            {
                target.Text = Cv((Math.Round((Convert.ToDouble(convert(target.Text, trgtbase, 10)) * Math.PI / 180), 8)).ToString());
            }
            catch { clear(); }
        }
        private void Last_Click(object sender, EventArgs e)//ANS button
        {
            target.Text = answer;

        }
        private void Ln_Click(object sender, EventArgs e) //Ln
        {
            try
            {
                if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
                double havana = Convert.ToDouble(convert(target.Text, trgtbase, 10));
                if (havana == 0 || Math.Sign(havana) == -1) return;
                havana = Math.Log(havana, Math.E);
                target.Text = Cv(havana.ToString());
            }
            catch { };
        }
        private void Logbtn_Click(object sender, EventArgs e)//Log 10
        {
            try
            {
                if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
                double havana = Convert.ToDouble(convert(target.Text, trgtbase, 10));
                if (havana == 0 || Math.Sign(havana) == -1) return;
                havana = Math.Log(havana);
                target.Text = Cv(havana.ToString());
            }
            catch { clear(); }
        }
        private void Factorial_Click(object sender, EventArgs e)
        {

            if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
            if (target.Text.Contains('.')) { target.Text = target.Text.Replace(target.Text.Substring(target.Text.IndexOf('.')), ""); }
            int havana = Convert.ToInt32(convert(target.Text, trgtbase, 10));
            havana = fact(havana);
            target.Text = Cv(havana.ToString());

        }
        int fact(int a)
        {
            try
            {
                if (a > 1) return (a * fact(a - 1));
                else return 1;
            }
            catch { clear(); return 0; }
        }
        private void Truncbtn_Click(object sender, EventArgs e)//Truncate
        {
            if (target.Text == "" || !target.Text.Contains('.')) return;
            target.Text = target.Text.Replace(target.Text.Substring(target.Text.IndexOf('.')), "");
        }
        private void absolute_Click(object sender, EventArgs e)
        {
            if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
            if (target.Text.Contains('-')) target.Text = target.Text.Replace("-", "");
        }
        private void Clrbtn_Click(object sender, EventArgs e)//Clear
        //operands and operators are also clared
        //the peogram is initialized from zero
        {
            clear();
        }
        void clear()
        {
            target.Text = "";
            svtxtbx.Text = "";
            op1 = 0; op2 = 0;
            opera = "";
            answer = "";
        }
        private void MultibleInverse_Click(object sender, EventArgs e)
        {
            try
            {
                if (target.Text == "" || target.Text == "-" || target.Text == "0.") return;
                double val = Math.Round((Convert.ToDouble(convert(target.Text, trgtbase, 10))));
                target.Text = Cv((Math.Round((1 / val), 8)).ToString());
            }
            catch { clear(); }
        }
        private void frctbtn_Click(object sender, EventArgs e) //get fraction part of a number
        {
            if (target.Text == "" || target.Text == "-" || target.Text == "0.") return;
            if (target.Text.Contains('.'))
                target.Text = "0" + target.Text.Substring(target.Text.IndexOf('.'));
        }
        private void pwrtow_Click(object sender, EventArgs e)//x^2 , unary
        {
            try
            {
                if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
                double havana = Convert.ToDouble(convert(target.Text, trgtbase, 10));
                havana = Math.Pow(havana, 2);
                target.Text = Cv(havana.ToString());
            }
            catch { clear(); }
        }
        private void pwrthree_Click(object sender, EventArgs e)
        {
            try
            {
                if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
                double havana = Convert.ToDouble(convert(target.Text, trgtbase, 10));//x^3 , unary
                havana = Math.Pow(havana, 3);
                target.Text = Cv(havana.ToString());
            }
            catch { clear(); }
        }
        private void powermin_Click(object sender, EventArgs e)//X^Y binary
        {
            try
            {
                if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
                double havana = Convert.ToDouble(convert(target.Text, trgtbase, 10));
                havana = Math.Pow(havana, -1);
                target.Text = Cv(havana.ToString());
            }
            catch { clear(); }
        }
        private void euler_Click(object sender, EventArgs e)
        {

            target.Text = Cv(Math.E.ToString());
        }
        private void Pi_Click(object sender, EventArgs e)
        {

            target.Text = Cv(Math.PI.ToString());
        }
        private void percent_Click(object sender, EventArgs e)
        {
            try
            {
                if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
                double havana = Convert.ToDouble(convert(target.Text, trgtbase, 10));
                havana = havana / 100;
                target.Text = Cv(havana.ToString());
            }
            catch { }

        }
        private void Exponential_Click(object sender, EventArgs e)
        {
            try
            {
                if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
                double havana = Convert.ToDouble(convert(target.Text, trgtbase, 10));
                havana = Math.Pow(Math.E, havana);
                target.Text = Cv(havana.ToString());
            }
            catch { clear(); }
        }
        private void Ceil_Click(object sender, EventArgs e)
        {
            if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
            double havana = Convert.ToDouble(convert(target.Text, trgtbase, 10));
            havana = Math.Ceiling(havana);
            target.Text = Cv(havana.ToString());
        }

        private void Floor_Click(object sender, EventArgs e)
        {
            if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
            double havana = Convert.ToDouble(convert(target.Text, trgtbase, 10));
            havana = Math.Floor(havana);
            target.Text = Cv(havana.ToString());
        }

        private void Slvbtn_Click(object sender, EventArgs e)
        {
            solv();
        }
        double complement(bool deminished, string toget)
        {//the complement of sellected base is calculated
            double N = Convert.ToDouble(convert(toget, trgtbase, 10));//number is converted to decimal
            if (N == 0) { target.Text = "0"; return 0; }
            int n = toget.Length;//number of digits
            double complement = Math.Pow(trgtbase, n) - N;
            if (deminished) { complement -= 1; }
            return complement;
        }
        private void Complmnt_Click(object sender, EventArgs e)
        {
            //a complement of a number is another number 
            // which if added to that number , parityflag overflows ,(give you a new digit)(9+1=10 two digits)
            //
            try
            {
                if (target.Text == "" || target.Text == "0." || target.Text == "-") return;
                string one = "";
                string two = "";
                if (target.Text.Contains('.'))
                {
                    one = target.Text.Substring(0, target.Text.IndexOf('.'));
                    string oned = Cv((complement(ChkDiminished.Checked, one)).ToString());
                    two = target.Text.Substring(target.Text.IndexOf('.') + 1);
                    string towed = Cv((complement(ChkDiminished.Checked, two)).ToString());
                    if (towed.Contains('-')) towed = towed.Replace("-", "");
                    target.Text = oned + (towed == "0" ? "" : "." + towed);


                }
                else
                {
                    Double steen = complement(ChkDiminished.Checked, target.Text);
                    target.Text = Cv(steen.ToString());
                }
            }
            catch { }
        }
        #endregion
        #region texts
        void hdsho(int lst) ///for buttons
        {
            //when used sellect a radio button , numbers which aren't available in it's base disappear
            string[] Dada = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            foreach (Control k in Bform.Controls)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (k.Text == Dada[i])
                    {
                        if (i <= lst) { k.Show(); } else { k.Hide(); }//Hide non-available numbers' buttons
                    }
                }
            }
            bintx.Show();
            dectx.Show();
            octx.Show();
            hextx.Show();
            svtxtbx.Show();
        }

        private void bintx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (target.Text != "" && target.Text.Last() == '.') { return; }//If used entered 2. wait untill he complete the fraction part 2.4
                //then convert
                if (!rdbin.Checked) return;
                dectx.Text = convert(target.Text, 2, 10);
                octx.Text = convert(target.Text, 2, 8);
                hextx.Text = convert(target.Text, 2, 16);

            }
            catch { bintx.Text = ""; octx.Text = ""; dectx.Text = ""; hextx.Text = ""; }
        }

        private void octx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (target.Text != "" && target.Text.Last() == '.') { return; }
                if (!rdoct.Checked) return;
                dectx.Text = convert(target.Text, 8, 10);
                bintx.Text = convert(target.Text, 8, 2);
                hextx.Text = convert(target.Text, 8, 16);

            }
            catch { bintx.Text = ""; octx.Text = ""; dectx.Text = ""; hextx.Text = ""; }
        }

        private void dectx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (target.Text != "" && target.Text.Last() == '.') { return; }
                if (!rddec.Checked) return;
                bintx.Text = convert(target.Text, 10, 2);
                octx.Text = convert(target.Text, 10, 8);
                hextx.Text = convert(target.Text, 10, 16);

            }
            catch { bintx.Text = ""; octx.Text = ""; dectx.Text = ""; hextx.Text = ""; }
        }

        private void hextx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (target.Text != "" && target.Text.Last() == '.') { return; }
                if (!rdhx.Checked) return;
                dectx.Text = convert(target.Text, 16, 10);
                octx.Text = convert(target.Text, 16, 8);
                bintx.Text = convert(target.Text, 16, 2);

            }
            catch { bintx.Text = ""; octx.Text = ""; dectx.Text = ""; hextx.Text = ""; }
        }
        #endregion


    }
}
