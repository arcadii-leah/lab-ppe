using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_Animation
{
    public partial class Form1 : Form
    {
        Graphics gr;       //объявляю объект - графику, на которой будем рисовать
        Pen p;             //объявляю объект - карандаш, которым будем рисовать контур
        SolidBrush fon;    // объявляю объект - заливки, для заливки соответственно фона
        SolidBrush fig;    //и внутренности рисуемой фигуры


        int rad;          // переменная для хранения радиуса рисуемых кругов
        Random rand;      // объект, для получения случайных чисел

        public Form1()
        {
            InitializeComponent();
        }

        //описываю функцию, которая будет рисовать круг по координат его центра
        void DrawCircle(int x, int y)
        {
            int xc, yc;
            xc = x - rad;
            yc = y - rad;
            gr.FillEllipse(fig, xc, yc, rad, rad);

            gr.DrawEllipse(p, xc, yc, rad, rad);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();  //инициализирую объект типа графики
                                                // привязав  к PictureBox

            p = new Pen(Color.Lime);           // задал цвет для карандаша 
            fon = new SolidBrush(Color.Black); // и для заливки
            fig = new SolidBrush(Color.Purple);

            rad = 40;                          //задали радиус для круга
            rand = new Random();               //инициализирую объект для рандомных числе

            gr.FillRectangle(fon, 0, 0, pictureBox1.Width, pictureBox1.Height); // закрасил черным 
                                                                                // нашу область рисования

            //вызываю написанную функцию, для прорисовки круга
            // буду рисовать просто пятнадцать кругов
            int x, y;

            for (int i = 0; i < 15; i++)
            {
                x = rand.Next(pictureBox1.Width);
                y = rand.Next(pictureBox1.Height);
                DrawCircle(x, y);
            }

            timer1.Enabled = true;  //включаю в работу таймер,
            // то есть теперь будет происходить событие Tick и его будет обрабатывать функция On_Tick (по умолчанию)

        }

        // для получения данной функции перехожу к конструктору формы 
        // и сделал двойной щелчок по таймеру
        private void timer1_Tick(object sender, EventArgs e)
        {

            //сначала буду очищать область рисования цветом фона
            gr.FillRectangle(fon, 0, 0, pictureBox1.Width, pictureBox1.Height);


            // затем опять случайным образом выбираю координаты точки 
            // и рисую их при помощи описанной функции
            int x, y;

            for (int i = 0; i < 15; i++)
            {
                x = rand.Next(pictureBox1.Width);
                y = rand.Next(pictureBox1.Height);
                DrawCircle(x, y);
            }

        }
    }
