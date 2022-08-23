using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReplicaForm.Models; //AGREGAMOS

namespace ReplicaForm.Controllers
{
    
    public class ReplicaFormController : Controller
    {
        private readonly ILogger<ReplicaFormController> _logger;

        public ReplicaFormController(ILogger<ReplicaFormController> logger)
        {
            _logger = logger;
        }

        public IActionResult VistaReplicaForm()
        {
            return View("VistaReplicaForm");
        }

[HttpPost]
        public IActionResult create(Persona objPersona)
        {
             string? nom=null, ape=null, job=null, date=null;
            
             String yearExperience=null;
             nom = objPersona.nombre;
             ape = objPersona.apellido;
             job = objPersona.job;
             yearExperience = objPersona.yearExperience;
             date = objPersona.date;

           //GUARDAR SEXO EN UNA VARIABLE
             //bool active;

            string listaSexo=null;
            List<sex> gen = objPersona.SexList;

            //listaSexo = objPersona.SexList == null ? "1" : "0";
            // si es nullo  1, sino es 0

            for (int i = 0; i < gen.Count; i++){
                if(gen[i].active == true){
                    listaSexo += gen[i].Type;
                }
                //listaSexo += gen[i].Type + " está " + (gen[i].active ? " marcado " : " desmarcado ");
                    //sale el genero + si esta marcado o desmarcado
            }

            //GUARDAR EL LEVEL OF EDUCATION
            //bool activeEducation ;
            string listaEducation=null;
            List<radio> radio = objPersona.RadioList;

            listaEducation = objPersona.RadioSelected; // == null ? "1" : "0";
/*
            for (int i = 0; i < radio.Count; i++){
                if(radio[i].active == true){
                    listaEducation += radio[i].Type; //no sale cual esta marcado
                }
               // listaEducation += radio[i].Type + " está " + (radio[i].active ? " marcado " : " desmarcado ");
                
            }
*/
            ViewData["Message"] =  nom + " " + ape + " check your email span in case you don't receive it";
            
            ViewData["Message1"]= "Sus Datos que fueron enviados son los siguiente:  ";
            ViewData["Message2"] = "Genero: " + listaSexo;
            ViewData["Message3"] = "Level of education: " + listaEducation;
            ViewData["Message4"] = "Job Title: " + job;
            ViewData["Message5"] = "Years of experience: " + yearExperience;
            ViewData["Message5"] = "Date: " + date;
            return View("VistaSubmit"); 
        }


[HttpGet]
public ActionResult VistaReplicaForm(Persona objPersona)
{
   
       var personas = new Persona 
    {
        //radio button de SEXO 
        SexList = new List<sex>
        {
            new sex{ID="1" , Type = "Male"}, 
            new sex{ID="2" , Type = "Female"},
             new sex{ID="3" , Type = "Prefer not to say"}
        }   , 

        //radio button de LEVEL OF EDUCATION
        RadioList = new List<radio>
        {
            new radio{ID="1" , Type = "High School"}, 
            new radio{ID="2" , Type = "College"}, 
            new radio{ID="3" , Type = "Grad School"}, 
        }
    } ;   

    return View(personas);//ENVIAMOS LA VARIABLE VAR
}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}