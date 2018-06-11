class CLIMenu
    {

        private string[] _MenuOptions; 
        private Func<object>[] _MenuFunctions;
        private byte[] _OptionNums;
        public CLIMenu(string[] menuOptions, Func<object>[] menuFunctions)
        {
            /* Class to construct a general-purpose CUI menu. 
            Takes an input of menu option strings, which are printed to the user for selection
            Takes an input of a Func<object> array. These are the functions which will be executed whenever
            The corresponding option is selected.
            */
            
            _MenuOptions = menuOptions;
            _MenuFunctions = menuFunctions;
        }

        // Add exception if menu options length is not equal to 
        // menu functions 

        public void PrintMenu()
        {   
            /* Prints menu to the console. Each menu is mapped to an integer value. */
            byte c = 0;
            foreach(string option in _MenuOptions)
            {
                Console.WriteLine("Enter {0} if you want to {1}", c + 1, _MenuOptions[c]);
                c++;
            }
            Console.WriteLine("Enter any other keys if you want to exit");
            Console.WriteLine("Your option: ");
        }
        
        

        public object RespondToInput(string input)
        {
            /* Executes relevant function based on a string input. 
            String must represent a number that corresponds a menu function  */
            try
            {
                byte index = Convert.ToByte(input);
                object obj;
                obj = _MenuFunctions[index - 1].Invoke();
                return obj;

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Option chosen does not correspond with a menu input value");
                return null;
            }



        }
        
    }
