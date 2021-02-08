using System;
using System.Collections.Generic;
using System.Text;
using ExerciseLandisGyr.Classes;

namespace ExerciseLandisGyr.Business
{
    interface IEndpointBusiness
    {
        public void Insert();
        public void Edit();
        public void Find();
        public void List();
        public void Remove();
        public void Menu();
        public void Exit();
    }
}
