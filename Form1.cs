using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Snake
{
    public partial class Form1 : Form
    {
        Panel[] Body = new Panel[1000]; //Das Body Array wird erstellt

        new bool Left, Right;
            bool Up, Down, ESC;

        bool[] move = new bool[4];

        int Score = 0, Geschindigkeit = 10, z1, SpawnpointX, SpawnpointY; //Durch das - 1 wird die weiße Box entfernt, warum muss ich noch rausfinden

        int[] LocationApfel, LocationHead;

        public Form1() //Hier wird der Spawn der Schlangeu und des Apfels beim sdtarten geregelt
        {
            InitializeComponent();
            LocationHead = RND(); //SpawnpointX und Y wird im Array LocationHead gespeichert. SpawnpointX und Y können dan mit LocationHead[0] und LocationHead[1] aufgerufen werden
            Head.Location = new Point(LocationHead[0], LocationHead[1]); //Die Schlande Spawn bei den zufällig gewählten Koordinaten (SpawnpointX und Y)
            LocationApfel = RND(); //SpawnpointX und Y wird im Array LocationBody gespeichert. SpawnpointX und Y können dan mit LocationBody[0] und LocationBody[1] aufgerufen werden
            Apfel.Location = new Point(LocationApfel[0], LocationApfel[1]); //Die Schlande Spawn bei den zufällig gewählten Koordinaten (SpawnpointX und Y)

            for (int i = 0; i < Body.Length; i++)
            {
                Body[i] = new Panel(); //Ein neues Body Panel wird erstellt
                Body[i].Size = new Size(10, 10); //Das Bodypanel erhällt seine Größe
                Body[i].BackColor = Color.FromArgb(128, 200, 128); //Das Bodypanel erhällt seine Größe
            }
        }

        private void MainTimer(object sender, EventArgs e) //Der Haupttimer der alles steuert. Die Regionen sollen es übersichtlicher machen
        {
            tlabel0.Text = Feld.Height.ToString();
            tlabel1.Text = Feld.Width.ToString();
            test.Text = Head.Location.ToString();
            tlabel2.Text = Apfel.Location.ToString();
            if (ESC == false) //Damit Pausiert werden kann
            {
                #region Kollision
                for (int z = 0; z <= Score; z++) //Damit geprüft werden kann, ob der Head in den Body gefahren ist
                {
                    if (Head.Location == Body[z].Location || Head.Top < 0 || Head.Bottom > Feld.Height || Head.Right > Feld.Width || Head.Left < 0) //Prüft auf Kollision
                    {
                        for (int i = 0; i <= Score; i++) //Wenn die Snake gegen die Wand fährt, verschwinden die Bodys
                        {
                            Body[i].Hide(); //Die Bodsy werden unsichtbar
                            Body[i].Location = new Point(10000, 10000); //Der Body wird aus dem Spielfeld teleportiert, da sonst der Body noch da ware. Nur halt unsichtbar
                        }

                        LocationHead = RND(); //SpawnpointX und Y wird im Array LocationHead gespeichert. SpawnpointX und Y können dan mit LocationHead[0] und LocationHead[1] aufgerufen werden
                        Head.Location = new Point(LocationHead[0], LocationHead[1]); //Die Schlande Spawn bei den zufällig gewählten Koordinaten (SpawnpointX und Y)
                        Up = false; //Damit die Schlange aufhört sich zu bewegen
                        Left = false; //Damit die Schlange aufhört sich zu bewegen
                        Down = false; //Damit die Schlange aufhört sich zu bewegen
                        Right = false; //Damit die Schlange aufhört sich zu bewegen

                        Score = 0;
                        Scoreboard.Text = "Score: " + Score;
                    }
                }
                #endregion

                int lastheadx = Head.Location.X; //Die Position des Heads wird gespeichert, bevor er einen weiter fährt. Damit der Body an der letzten Postion des Hedas spawnen kann
                int lastheady = Head.Location.Y;

                #region Bewegung
                //Die Bewegungs des Heads
                if (Up == true) //Prüft ob Up auf true ist, falls ja, fährt die Schlange nach oben
                {
                    Head.Top -= Geschindigkeit;
                    move[0] = true;
                    move[1] = false;
                    move[2] = false;
                    move[3] = false;
                }
                if (Left == true) //Prüft ob Left auf true ist, falls ja, fährt die Schlange nach links
                {
                    Head.Left -= Geschindigkeit;
                    move[0] = false;
                    move[1] = true;
                    move[2] = false;
                    move[3] = false;
                }
                if (Down == true) //Prüft ob Down auf true ist, falls ja, fährt die Schlange nach unten
                {
                    Head.Top += Geschindigkeit;
                    move[0] = false;
                    move[1] = false;
                    move[2] = true;
                    move[3] = false;
                }
                if (Right == true) //Prüft ob Right auf true ist, falls ja, fährt die Schlange nach rechts
                {
                    Head.Left += Geschindigkeit;
                    move[0] = false;
                    move[1] = false;
                    move[2] = false;
                    move[3] = true;
                }

                //Die Bewegung der Bodys
                if (z1 > (Score - 1))
                {
                    z1 = 0;
                }
                if (Head.Location.X != lastheadx || Head.Location.Y != lastheady) //Damit der erste Body nicht im Head gespawnt wird
                {
                    Body[z1].Location = new Point(lastheadx, lastheady); //Der Body wird zum letzten punkt des heads telleportiert
                }
                z1++;
                #endregion

                #region Apfel wird berührt
                if (Head.Location == Apfel.Location) //Wenn die Schlange den Apfel berührt passiert folgendes:
                {
                    Body[Score].Show(); //Die Bodsy werden awieder sichtbar
                    Body[Score].Location = new Point(lastheadx, lastheady); //Der body wird an der letzten Postion des heads gespawnnt
                    Feld.Controls.Add(Body[Score]); //Das Bodypanel wird mittels eines Arrays erstellt
                    Score++; //Wenn ein Apfel gegesen wurde, erhöht sich der Score

                    Scoreboard.Text = "Score: " + Score;

                    LocationApfel = RND(); //SpawnpointX und Y wird im Array LocationBody gespeichert. SpawnpointX und Y können dan mit LocationBody[0] und LocationBody[1] aufgerufen werden
                    Apfel.Location = new Point(LocationApfel[0], LocationApfel[1]); //Die Schlande Spawn bei den zufällig gewählten Koordinaten (SpawnpointX und Y)
                }
                #endregion
            }

        }

        private void Drücken(object sender, KeyEventArgs e) //Die Steuerung
        {
            if (e.KeyCode == Keys.Escape) //Wenn ESC gedrückt wird, wird dass Game pausiert
            {
                ESC = true;
                Up = false;
                Left = false;
                Down = false;
                Right = false;
            }
            if (e.KeyCode == Keys.W && move[2] == false) //Wenn die Taste W gedrückt wird und die Schlange nicht nach unten Fährt, passiert folgendes:
            {
                ESC = false;
                Up = true; //Up wird auf truze gestellt, damit die die Schlange nach oben fahren kann
                Left = false; //Alle anderen eingaben werden deaktiviert
                Down = false;
                Right = false;
            }

            if (e.KeyCode == Keys.A && move[3] == false) //Wenn die Taste A gedrückt wird und die Schlange nicht nach unten Fährt, passiert folgendes:
            {
                ESC = false;
                Left = true; //Left wird auf truze gestellt, damit die die Schlange nach links fahren kann
                Up = false; //Alle anderen eingaben werden deaktiviert
                Down = false;
                Right = false;
            }
             
            if (e.KeyCode == Keys.S && move[0] == false) //Wenn die Taste S gedrückt wird und die Schlange nicht nach unten Fährt, passiert folgendes:
            {
                ESC = false;
                Down = true; //Down wird auf truze gestellt, damit die die Schlange nach unten fahren kann
                Up = false; //Alle anderen eingaben werden deaktiviert
                Left = false;
                Right = false;
            }

            if (e.KeyCode == Keys.D && move[1] == false) //Wenn die Taste D gedrückt wird und die Schlange nicht nach unten Fährt, passiert folgendes:
            {
                ESC = false;
                Right = true; //Right wird auf truze gestellt, damit die die Schlange nach oben fahren kann
                Up = false; //Alle anderen eingaben werden deaktiviert
                Left = false;
                Down = false;
            }
        }

        int[] RND()
        { 
            Random rnd1 = new Random(); //rnd1 wird erstellt
            SpawnpointX = rnd1.Next(1, (250 / 10)); //SpawnpointX kriegt einen Wert zwischen 1 und 25 zugewiesen
            SpawnpointX *= 10; //Dieser Wert wird * 10 genommen 
            SpawnpointY = rnd1.Next(1, (250 / 10));
            SpawnpointY *= 10;
            return new int[] { SpawnpointX, SpawnpointY }; //SpawnpointX und Y wird in einem Array an RND zurückgegeben. Bei der Deklaration später muss ein Neues Array mit einem Namen erstelt werden. SpwnpointX kann dann so verwendet werden: int[] Array = RND(); Console.WriteLine(Array[0]);
        }
    }
}
