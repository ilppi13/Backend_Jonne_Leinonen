using System;

namespace web_api
{
    public class PlayerAlligatorException : Exception
    {
        public PlayerAlligatorException():base("Error your powerlevel is too low"){
            
        }
    }
}