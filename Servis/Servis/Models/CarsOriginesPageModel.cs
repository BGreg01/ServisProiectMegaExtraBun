using Microsoft.AspNetCore.Mvc.RazorPages;
using Servis.Data;



namespace Servis.Models
{
    public class CarsOriginesPageModel:PageModel

    {
        public List<AssignedOrigineData> AssignedOrigineDataList;
        public void PopulateAssignedOrigineData(ServisContext context,
        Car car)
        {
            var allOrigines = context.Origine;
            var carOrigines = new HashSet<int>(
            car.CarOrigines.Select(c => c.OrigineID)); //
            AssignedOrigineDataList = new List<AssignedOrigineData>();
            foreach (var cat in allOrigines)
            {
                AssignedOrigineDataList.Add(new AssignedOrigineData
                {
                   OrigineID = cat.ID,
                    Name = cat.OrigineName,
                    Assigned = carOrigines.Contains(cat.ID)
                });
            }
        }
        public void UpdateCarOrigine(ServisContext context,
        string[] selectedOrigines, Car carToUpdate)
        {
            if (selectedOrigines == null)
            {
                carToUpdate.CarOrigines = new List<CarOrigine>();
                return;
            }
            var selectedOriginesHS = new HashSet<string>(selectedOrigines);
            var carOrigines = new HashSet<int>
            (carToUpdate.CarOrigines.Select(c => c.Origine.ID));
            foreach (var cat in context.Origine)
            {
                if (selectedOriginesHS.Contains(cat.ID.ToString()))
                {
                    if (!carOrigines.Contains(cat.ID))
                    {
                        carToUpdate.CarOrigines.Add(
                        new CarOrigine
                        {
                           CarID = carToUpdate.ID,
                           OrigineID = cat.ID
                        });
                    }
                }
                else
                {
                    if (carOrigines.Contains(cat.ID))
                    {
                        CarOrigine courseToRemove
                        = carToUpdate
                        .CarOrigines
                        .SingleOrDefault(i => i.OrigineID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }




    }
                }
