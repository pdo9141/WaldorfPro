using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Waldorf.DataModel;
using Waldorf.Domain;
using Waldorf.Web.ViewModels.Colleague;
using Waldorf.Domain.Enums;

namespace Waldorf.Web.Controllers
{
    public class ColleagueController : Controller
    {
        private WaldorfContext db = new WaldorfContext();

        // GET: Colleague
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("StepOne", "Colleague");
            else
                return View(db.Parties.ToList());
        }

        public ActionResult StepOne()
        {
            var model = new StepOneViewModel();
            var userId = User.Identity.GetUserId();
            using (var context = new WaldorfContext())
            {
                var party = context.Parties.First(p => p.UserId.Equals(userId));
                model.FirstName = party.FirstName ?? String.Empty;
                model.LastName = party.LastName ?? String.Empty;
                model.EmailAddress = party.EmailAddress ?? String.Empty;
                model.ConfirmEmailAddress = model.EmailAddress;
                model.ZipCode = party.ZipCode ?? String.Empty;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StepOne(StepOneViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                using (var context = new WaldorfContext())
                {
                    var party = context.Parties.First(p => p.UserId.Equals(userId));
                    party.FirstName = model.FirstName;
                    party.LastName = model.LastName;
                    party.EmailAddress = model.EmailAddress;
                    party.ZipCode = model.ZipCode;
                    context.SaveChanges();
                }
                
                return RedirectToAction("StepTwo");
            }

            return View(model);
        }

        public ActionResult StepTwo(FormCollection formCollection)
        {
            var model = new StepTwoViewModel();
            model.TeacherJobPositionsOfInterest = PopulateTeacherJobPositionsOfInterest(formCollection);
            model.AdminJobPositionsOfInterest = PopulateAdminJobPositionsOfInterest(formCollection);
            return View(model);
        }

        private List<JobPositionOfInterestViewModel> PopulateTeacherJobPositionsOfInterest(FormCollection formCollection)
        {
            var result = new List<JobPositionOfInterestViewModel>();
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.PreSchoolLeadTeacher });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.PreSchoolAssistant });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.KindergartenLeadTeacher });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.KindergartenAssistant });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.GradesLeadTeacher });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.GradesAssistant });

            var highSchoolTeacher = new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.HighSchoolTeacher };
            highSchoolTeacher.Categories.Add(new JobPositionTierOneCategoryViewModel { JobPositionTierOneCategoryType = JobPositionTierOneCategoryType.Sciences });
            highSchoolTeacher.Categories.Add(new JobPositionTierOneCategoryViewModel { JobPositionTierOneCategoryType = JobPositionTierOneCategoryType.Humanities });
            highSchoolTeacher.Categories.Add(new JobPositionTierOneCategoryViewModel { JobPositionTierOneCategoryType = JobPositionTierOneCategoryType.Math });
            highSchoolTeacher.Categories.Add(new JobPositionTierOneCategoryViewModel { JobPositionTierOneCategoryType = JobPositionTierOneCategoryType.Technology });

            var worldLanguages = new JobPositionTierOneCategoryViewModel { JobPositionTierOneCategoryType = JobPositionTierOneCategoryType.WorldLanguages };
            worldLanguages.Categories.Add(new JobPositionTierTwoCategoryViewModel { JobPositionTierTwoCategoryType = JobPositionTierTwoCategoryType.Spanish });
            worldLanguages.Categories.Add(new JobPositionTierTwoCategoryViewModel { JobPositionTierTwoCategoryType = JobPositionTierTwoCategoryType.German });
            worldLanguages.Categories.Add(new JobPositionTierTwoCategoryViewModel { JobPositionTierTwoCategoryType = JobPositionTierTwoCategoryType.French });
            worldLanguages.Categories.Add(new JobPositionTierTwoCategoryViewModel { JobPositionTierTwoCategoryType = JobPositionTierTwoCategoryType.Mandarin });
            worldLanguages.Categories.Add(new JobPositionTierTwoCategoryViewModel { JobPositionTierTwoCategoryType = JobPositionTierTwoCategoryType.Japanese });
            
            highSchoolTeacher.Categories.Add(worldLanguages);
            highSchoolTeacher.Categories.Add(new JobPositionTierOneCategoryViewModel { JobPositionTierOneCategoryType = JobPositionTierOneCategoryType.Music });
            highSchoolTeacher.Categories.Add(new JobPositionTierOneCategoryViewModel { JobPositionTierOneCategoryType = JobPositionTierOneCategoryType.PracticalFinePerformingArts });
            highSchoolTeacher.Categories.Add(new JobPositionTierOneCategoryViewModel { JobPositionTierOneCategoryType = JobPositionTierOneCategoryType.PhysicalEducationMovement });
            highSchoolTeacher.Categories.Add(new JobPositionTierOneCategoryViewModel { JobPositionTierOneCategoryType = JobPositionTierOneCategoryType.Eurhythmy });

            result.Add(highSchoolTeacher);
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.HighSchoolAssistant });

            foreach (var jobPositionOfInterestViewModel in result)
            {
                if (formCollection["cbTeacherJobInterest" + jobPositionOfInterestViewModel.Id] != null)
                    jobPositionOfInterestViewModel.Selected = true;

                var tierOneCategorySelectedValue = formCollection["ddlTeacherTierOneCategory" + jobPositionOfInterestViewModel.Id] ?? String.Empty;
                
                foreach (var tierOneCategory in jobPositionOfInterestViewModel.Categories)
                {
                    if (tierOneCategory.Id.ToString().Equals(tierOneCategorySelectedValue))
                        tierOneCategory.Selected = true;

                    var tierTwoCategorySelectedValue = formCollection["ddlTeacherTierTwoCategory" + tierOneCategory.Id] ?? String.Empty;                    
                    foreach (var tierTwoCategory in tierOneCategory.Categories)
                    {
                        if (tierTwoCategory.Id.ToString().Equals(tierTwoCategorySelectedValue))
                            tierTwoCategory.Selected = true;
                    }
                }
            }

            return result;
        }

        private List<JobPositionOfInterestViewModel> PopulateAdminJobPositionsOfInterest(FormCollection formCollection)
        {
            var result = new List<JobPositionOfInterestViewModel>();
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.AdministrativeDirector });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.PedagogicalChair });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.DevelopmentDirector });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.Enrollment });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.Registrar });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.LowerOrHighSchoolCoordinator });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.OfficeSupport });
            result.Add(new JobPositionOfInterestViewModel { JobPositionType = JobPositionType.AccountingFinance });

            foreach (var jobPositionOfInterestViewModel in result)
                if (formCollection["cbAdminJobInterest" + jobPositionOfInterestViewModel.Id] != null)
                    jobPositionOfInterestViewModel.Selected = true;
                       
            return result;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StepTwo(StepTwoViewModel model, FormCollection formCollection)
        {
            model.TeacherJobPositionsOfInterest = PopulateTeacherJobPositionsOfInterest(formCollection);
            model.AdminJobPositionsOfInterest = PopulateAdminJobPositionsOfInterest(formCollection);

            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                using (var context = new WaldorfContext())
                {
                    var party = context.Parties.First(p => p.UserId.Equals(userId));
                    party.PreferredName = model.OtherNamePreferred;
                    AddPartyTypes(party, model.ColleagueType);
                    AddJobPositionsOfInterest(party, model.TeacherJobPositionsOfInterest);
                    AddJobPositionsOfInterest(party, model.AdminJobPositionsOfInterest);

                    context.SaveChanges();
                }
                return RedirectToAction("StepThree");
            }

            return View(model);
        }
        
        private void AddPartyTypes(Party party, string colleagueType)
        {
            switch (colleagueType)
            {
                case "Teacher":
                    party.PartyTypes.Add(PartyType.Teacher);
                    break;
                case "Administrator":
                    party.PartyTypes.Add(PartyType.Administrator);
                    break;
                case "TeacherAdministrator":
                    party.PartyTypes.Add(PartyType.Teacher);
                    party.PartyTypes.Add(PartyType.Administrator);
                    break;
            }
        }

        private void AddJobPositionsOfInterest(Party party, List<JobPositionOfInterestViewModel> jobPositionOfInterestViewModels)
        {
            foreach (var jobPositionOfInterestViewModel in jobPositionOfInterestViewModels)
            {
                if (jobPositionOfInterestViewModel.Selected)
                {
                    var jobPosition = new JobPositionWrapper { JobPositionType = jobPositionOfInterestViewModel.JobPositionType };
                    foreach (var jobPositionTierOneCategoryViewModel in jobPositionOfInterestViewModel.Categories)
                    {
                        if (jobPositionTierOneCategoryViewModel.Selected)
                        {
                            var jobPositionTierOneCategory = new JobPositionTierOneCategory { JobPositionTierOneCategoryType = jobPositionTierOneCategoryViewModel.JobPositionTierOneCategoryType };
                            foreach (var jobPositionTierTwoCategoryViewModel in jobPositionTierOneCategoryViewModel.Categories)
                            {
                                if (jobPositionTierTwoCategoryViewModel.Selected)
                                {
                                    var jobPositionTierTwoCategory = new JobPositionTierTwoCategory { JobPositionTierTwoCategoryType = jobPositionTierTwoCategoryViewModel.JobPositionTierTwoCategoryType };
                                    jobPositionTierOneCategory.JobPositionTierTwoCategory = jobPositionTierTwoCategory;
                                }
                            }

                            jobPosition.JobPositionTierOneCategory = jobPositionTierOneCategory;
                        }
                    }

                    party.JobPositionsOfInterest.Add(jobPosition);
                }
            }
        }

        // GET: Colleague/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        // GET: Colleague/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colleague/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PartyStatusType,FirstName,LastName,EmailAddress,ZipCode,AnthroposophicalFoundationalStudies,AllowSchoolMatchWithoutApproval,WaldorfTranscriptFileName,AnyWaldorfAdminCertUnitsCompleted,BiographyFileName,PreferredName,ProfileImageName,UserId,DateCreated")] Party party)
        {
            if (ModelState.IsValid)
            {
                db.Parties.Add(party);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(party);
        }

        // GET: Colleague/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        // POST: Colleague/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PartyStatusType,FirstName,LastName,EmailAddress,ZipCode,AnthroposophicalFoundationalStudies,AllowSchoolMatchWithoutApproval,WaldorfTranscriptFileName,AnyWaldorfAdminCertUnitsCompleted,BiographyFileName,PreferredName,ProfileImageName,UserId,DateCreated")] Party party)
        {
            if (ModelState.IsValid)
            {
                db.Entry(party).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(party);
        }

        // GET: Colleague/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        // POST: Colleague/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Party party = db.Parties.Find(id);
            db.Parties.Remove(party);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
