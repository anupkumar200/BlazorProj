using BlazorProj.Models;

namespace BlazorProj.Clients.Programs
{
    public class ProgramClients
    {
        private readonly List<Programm> program =
        [
            new(){
                Id =1,
                Name = "Farewell",
                CaseManager = "Jack William",
                Status = true,
                UpdatedOn = DateTime.Now,
            },
            new(){
                Id = 2,
                Name = "Retirement",
                CaseManager = "Peter Parker",
                Status = false,
                UpdatedOn = DateTime.Now
            },
            new(){
                Id = 3,
                Name = "Promotion",
                CaseManager = "Evan",
                Status = true,
                UpdatedOn = DateTime.Now
            },
            new(){
                Id = 4,
                Name = "Fresher Party",
                CaseManager ="Mark Hood",
                Status = false,
                UpdatedOn = DateTime.Now
            },
            new(){
                Id = 5,
                Name = "Concert",
                CaseManager = "Janny",
                Status = true,
                UpdatedOn = DateTime.Now
            }
        ];
        public Programm[] GetProgram() => [.. program];

        public void AddProgram(ProgramDetails objPro)
        {
            var prog = new Programm
            {
                Id = program.Count + 1,
                Name = objPro.Name,
                CaseManager = objPro.CaseManager,
                Status = objPro.Status,
                UpdatedOn = DateTime.Now
            };
            program.Add(prog);
        }
        public ProgramDetails GetProgram(long id)
        {
            Programm programm = GetProgramById(id);
            return new ProgramDetails
            {
                Id = programm.Id,
                Name = programm.Name,
                CaseManager = programm.CaseManager,
                Status = programm.Status,
                UpdatedOn = DateTime.Now
            };
        }
        private Programm GetProgramById(long id)
        {
            Programm? prog = program.Find(p => p.Id == id);
            ArgumentNullException.ThrowIfNull(prog);
            return prog;
        }
        public void UpdateProgram(ProgramDetails updateProgram)
        {
            var existingProgram = GetProgramById(updateProgram.Id);

            existingProgram.Name = updateProgram.Name;
            existingProgram.CaseManager = updateProgram.CaseManager;
            existingProgram.Status = updateProgram.Status;
            existingProgram.UpdatedOn = DateTime.Now;
        }

        public void DeleteProgram(long id)
        {
            var prog = GetProgramById(id);
            program.Remove(prog);
        }
    }
}
