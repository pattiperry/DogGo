using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Repositories;
using DogGo.Models;
using System.Security.Claims;

namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {
        private readonly IWalkerRepository _walkerRepo;
        private readonly IOwnerRepository _ownerRepo;
        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalkersController(IWalkerRepository walkerRepository,
                                 IOwnerRepository ownerRepository)
        {
            _walkerRepo = walkerRepository;
            _ownerRepo = ownerRepository;
        }

        // GET: WalkersController
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();
            if(ownerId == 0)
            {
                List<Walker> allWalkers = _walkerRepo.GetAllWalkers();
                return View(allWalkers);
            }
           
            //pulls in the entire owner object(which has a neighborhoodId on it)
            Owner currentOwner = _ownerRepo.GetOwnerById(ownerId);

            //this code will get all the walkers in the Walker table
            //convert it to a list and pass it off to the view
            List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(currentOwner.NeighborhoodId);



            return View(walkers);

            
        }

        private int GetOwnerById()
        {
            throw new NotImplementedException();
        }

        // GET: WalkersController/Details/5
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);

            if (walker == null)
            {
                return NotFound();
            }

            return View(walker);
        }

        // GET: WalkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int GetCurrentUserId()
        {
          
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(id == null)
            {
                id = "0";
            }
            return int.Parse(id);
        }


    }
}
