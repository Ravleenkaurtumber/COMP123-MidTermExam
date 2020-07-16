using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123_MidTermExam
{
    /**
     * <summary>
     * This abstract class is a blueprint for all Lotto Games
     * </summary>
     * 
     * @class LottoGame
     * @property {int} ElementNum;
     * @property {int} SetSize;
     */
    public abstract class LottoGame
    {
        // PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private List<int> m_elementList;

        private int m_elementNumber;

        private List<int> m_numberList;

        private Random m_random;

        private int m_setSize;
        // PUBLIC PROPERTIES ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE public properties here -----------------------------------------
        // The property ElementList which will contain the random numbers generated from the NumberList
        public List<int> ElementList
        {
            get
            {
                return m_elementList;
            }
        }
        //ElementNumber stores the number of time the random number need to be genrated according to lottery system
        public int ElementNumber
        {
            get
            {
                return m_elementNumber;
            }
            set
            {
                m_elementNumber = value;
            }
        }
        //Property NumberList stores all the numbers from 1 to setsize(49)
        public List<int> NumberList
        {
            get
            {
                return m_numberList;
            }
        }
        //for random numbers
        public Random random
        {
            get
            {
                return m_random;

            }
        }
        //setsize for the limit of numbers in numberlist(49)
        public int SetSize
        {
            get
            {
                return m_setSize;
            }
            set
            {
                m_setSize = value;
            }
        }
        
       

        // CONSTRUCTORS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * This constructor takes two parameters: elementNumber and setSize
         * The elementNumber parameter has a default value of 6
         * The setSize parameter has a default value of 49
         * </summary>
         * 
         * @constructor LottoGame
         * @param {int} elementNumber
         * @param {int} setSize
         */
        public LottoGame(int elementNumber = 6, int setSize = 49)
        {
            // assign elementNumber local variable to the ElementNumber property
            this.ElementNumber = elementNumber;

            // assign setSize local variable tot he SetSize property
            this.SetSize = setSize;

            // call the _initialize method
            this.m_initialize();

            // call the _build method
            this.m_build();
        }

        // PRIVATE METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE the private _initialize method here -----------------------------
        //this method will instantiate new objects for the private fields
        private void m_initialize()
        {
            m_numberList=new List<int>();
            m_elementList = new List<int>();
            m_random=new Random();

        }
        // CREATE the private _build method here -----------------------------------
        // To store the numbers in numberlist
        private void m_build()
        {
            for (int i = 1; i <= SetSize; i++)
            {
                NumberList.Add(i);
            }

        }
        // OVERRIDEN METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * Override the default ToString function so that it displays the current
         * ElementList
         * </summary>
         * 
         * @override
         * @method ToString
         * @returns {string}
         */
        public override string ToString()
        {
            // create a string variable named lottoNumberString and intialize it with the empty string
            string lottoNumberString = String.Empty;

            // for each lottoNumber in ElementList, loop...
            foreach (int lottoNumber in ElementList)
            {

                // add lottoNumber and appropriate spaces to the lottoNumberString variable
                lottoNumberString += lottoNumber > 9 ? (lottoNumber + " ") : (lottoNumber + "  ");
            }



            return lottoNumberString;
        }

        // PUBLIC METHODS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE the public PickElements method here ----------------------------
        /// <summary>
        /// pickElements this method generate random numbers.
        /// after generating remove from numberList and add to elementlist
        /// </summary>
        public void PickElements()
        {
            int currentRandom;
            bool ElementListempty = !ElementList.Any();
            bool NumberListempty = !NumberList.Any();
            //checking if the elementList and NumberList are empty or not 

            if (ElementListempty != true || NumberListempty != true)
            {
                //if the lists contain some values the clear is used to make them empty 
                ElementList.Clear();
                NumberList.Clear();
                m_build();// will fill the numberList
                for (int j = 1; j <= ElementNumber; j++)
                {
                    currentRandom = m_random.Next(1,NumberList.Count);
                    NumberList.Remove(currentRandom);
                    ElementList.Add(currentRandom);

                }

                ElementList.Sort();//sorting the list

            }
        }

    }
    }

