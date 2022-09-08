using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Marble_Game
{
    class MarblePictureBox : PictureBox
    {
        private int Ball;
        private int Hole;
        private bool LeftWall = false;
        private bool RightWall = false;
        private bool TopWall = false;
        private bool BottomWall = false;
        private bool error = false;

        public bool Error
        {
            set
            {
                error = value;
            }

            get
            {
                return error;
            }
        }



        public int Balls
        {
            set
            {
                Ball = value;
            }

            get
            {
                return Ball;
            }
        }

        public int Holes
        {
            set
            {
                Hole = value;
            }

            get
            {
                return Hole;
            }

        }

        public bool leftwall
        {
            set
            {
                LeftWall = value;
            }

            get
            {
                return LeftWall;
            }

        }

        public bool rightwall
        {
            set
            {
                RightWall = value;
            }

            get
            {
                return RightWall;
            }

        }

        public bool topwall
        {
            set
            {
                TopWall = value;
            }

            get
            {
                return TopWall;
            }

        }

        public bool bottomwall
        {
            set
            {
                BottomWall = value;
            }

            get
            {
                return BottomWall;
            }

        }

    }
}

