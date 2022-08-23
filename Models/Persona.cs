using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace ReplicaForm.Models
{
    public class Persona
    {
         [Display(Name = "First Name", Prompt = "Enter your First Name")]
        public string? nombre{get; set;}
         [Display(Name = "Last Name", Prompt = "Enter your Last Name")]
        public string? apellido{get; set;}
        [Display(Name = "Job title", Prompt = "Enter your Job Title")]
        public string? job{get; set;}

//RADIO BUTTON DE SEXO
        [Required(ErrorMessage = "Sex Required")]
         [Display(Name = "Sex :")]
        public sex? Gender { get; set; }

        public List<sex>? SexList { get; set; }
//RADIO BUTTON LEVEL OF EDUCATION
        public radio? Radio { get; set; }
        public string? RadioSelected { get; set; }

        public List<radio>? RadioList { get; set; }
//--------------------------
        public string? yearExperience { get; set; }
        public string? date { get; set; }


    }
    /*
  public class InputModel
        {
             
            //[Required]
            [Display(Name = "yearExperience")]
             public int yearExperience { get; set; }
        }
   */

    public class sex
    {
        public string? ID {get;set;}
    
        public string? Type {get;set;}
        public bool active {get;set;}
    }

    public class radio
    {
        public string? ID { get; set; }
        public string? Type { get; set; }
        public bool active {get;set;}
    }
}