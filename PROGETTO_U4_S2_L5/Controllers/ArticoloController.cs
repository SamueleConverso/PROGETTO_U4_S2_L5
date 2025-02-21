using Microsoft.AspNetCore.Mvc;
using PROGETTO_U4_S2_L5.Models;

namespace PROGETTO_U4_S2_L5.Controllers {
    public class ArticoloController : Controller {

        private static List<Articolo> ArticoliListaStatica = new List<Articolo>() {
            new Articolo {
                Id = Guid.NewGuid(),
                Nome = "Articolo 1",
                Prezzo = 10,
                Descrizione = "Descrizione articolo 1",
                Immagine = "https://img.freepik.com/foto-gratuito/scarpe-sportive-da-corsa_1203-3414.jpg?t=st=1740131879~exp=1740135479~hmac=e69d605cad33e9aa1754aeae482377aeee55babf7a17b3c9c606a697853499d6&w=1800",
                ImmagineAggiuntiva1 = "",
                ImmagineAggiuntiva2 = ""
            },
            new Articolo {
                Id = Guid.NewGuid(),
                Nome = "Articolo 2",
                Prezzo = 100,
                Descrizione = "Descrizione articolo 2",
                Immagine = "https://img.freepik.com/foto-gratuito/scarpe-sportive-da-corsa_1203-3414.jpg?t=st=1740131879~exp=1740135479~hmac=e69d605cad33e9aa1754aeae482377aeee55babf7a17b3c9c606a697853499d6&w=1800",
                ImmagineAggiuntiva1 = "",
                ImmagineAggiuntiva2 = ""
            },
        };

        [HttpGet("articolo")]
        public IActionResult Index() {
            var articoliViewModel = new ArticoloViewModel {
                Articoli = ArticoliListaStatica
            };
            return View(articoliViewModel);
        }

        [HttpGet("articolo/nuovo-ordine")]
        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public IActionResult Ordina(Articolo articolo) {
            if (!ModelState.IsValid) {
                return RedirectToAction("Add");
            }

            var nuovoArticolo = new Articolo {
                Id = Guid.NewGuid(),
                Nome = articolo.Nome,
                Prezzo = articolo.Prezzo,
                Descrizione = articolo.Descrizione,
                Immagine = articolo.Immagine,
                ImmagineAggiuntiva1 = articolo.ImmagineAggiuntiva1,
                ImmagineAggiuntiva2 = articolo.ImmagineAggiuntiva2
            };

            ArticoliListaStatica.Add(nuovoArticolo);
            return RedirectToAction("Index");
        }

        [HttpGet("articolo/dettagli/{id:guid}")]
        public IActionResult Details(Guid id) {
            var existingArticolo = ArticoliListaStatica.FirstOrDefault(a => a.Id == id);

            if (existingArticolo == null) {
                return RedirectToAction("Index");
            }

            var articoloDetails = new ArticoloDetails {
                Id = existingArticolo.Id,
                Nome = existingArticolo.Nome,
                Prezzo = existingArticolo.Prezzo,
                Descrizione = existingArticolo.Descrizione,
                Immagine = existingArticolo.Immagine,
                ImmagineAggiuntiva1 = existingArticolo.ImmagineAggiuntiva1,
                ImmagineAggiuntiva2 = existingArticolo.ImmagineAggiuntiva2
            };

            return View(articoloDetails);
        }

        [HttpGet("articolo/delete/{id:guid}")]
        public IActionResult Delete(Guid id) {
            var existingArticolo = ArticoliListaStatica.FirstOrDefault(a => a.Id == id);
            if (existingArticolo == null) {
                return RedirectToAction("Index");
            }
            bool articoloToDelete = ArticoliListaStatica.Remove(existingArticolo);
            if (!articoloToDelete) {
                return RedirectToAction("Index");
            } else {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("articolo/edit/{id:guid}")]
        public IActionResult Edit(Guid id) {
            var existingArticolo = ArticoliListaStatica.FirstOrDefault(a => a.Id == id);

            if (existingArticolo == null) {
                return RedirectToAction("Index");
            }

            var articoloEdit = new ArticoloEdit {
                Id = existingArticolo.Id,
                Nome = existingArticolo.Nome,
                Prezzo = existingArticolo.Prezzo,
                Descrizione = existingArticolo.Descrizione,
                Immagine = existingArticolo.Immagine,
                ImmagineAggiuntiva1 = existingArticolo.ImmagineAggiuntiva1,
                ImmagineAggiuntiva2 = existingArticolo.ImmagineAggiuntiva2
            };

            return View(articoloEdit);
        }
    }
}
