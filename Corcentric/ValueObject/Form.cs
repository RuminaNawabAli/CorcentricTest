namespace Corcentric.ValueObject
{
    class Form
    {
        private string _fistname;
        private string _lastname;
        private string _usernumber;
        private string _gender;

        public string Fistname { get { return _fistname; }  private set { } }
        public string Lastname { get { return _lastname; } private set { } }
        public string Usernumber { get { return _usernumber; } private set { } }
        public string Gender { get { return _gender; } private set { } }

        public Form(string firstname, string lastname, string number,string gender)
        {
            _fistname = firstname;
            _lastname = lastname;
            _usernumber = number;
            _gender = gender;
        }
     

    }
}
