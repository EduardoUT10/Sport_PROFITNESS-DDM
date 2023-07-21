using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

using Sport.Models;
using System.Threading.Tasks;

namespace Sport.Services
{
    public class ExerciseDatabase
    {

        /// <summary>
        /// Get list table Exercise async
        /// </summary>
        /// <returns>List Exercise</returns>
        public Task<List<Exercise>> GetExerciseAsync()
        {
            return App._database.Table<Exercise>().ToListAsync();
        }

        /// <summary>
        /// Get Exercise with variable id
        /// </summary>
        /// <param name="id">id Exercise</param>
        /// <returns>Exercise</returns>
        public Task<Exercise> GetExerciseAsync(int id)
        {
            return App._database.Table<Exercise>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Search Exercise
        /// </summary>
        /// <param name="a">string text</param>
        /// <returns>List of exercise</returns>
        public Task<List<Exercise>> SearchExerciseAsync(string a)
        {
            string searchNoSpaces = a.Replace(" ", "%");
            var get_docnumb = App._database.QueryAsync<Exercise>("SELECT * FROM Exercise WHERE Name LIKE ?", "%" + searchNoSpaces + "%");

            return get_docnumb;
        }

        /// <summary>
        /// Update or Insert Exercise
        /// </summary>
        /// <param name="exercise">Class Exercise</param>
        /// <returns></returns>
        public Task<int> SaveExerciseAsync(Exercise exercise)
        {
            if (exercise.Id != 0)
                return App._database.UpdateAsync(exercise);
            else
            {
                return App._database.InsertAsync(exercise);
            }
        }

        /// <summary>
        /// Delete Exercise
        /// </summary>
        /// <param name="exercise">Class Exercise</param>
        /// <returns></returns>
        public Task<int> DeleteExerciselAsync(Exercise exercise)
        {
            return App._database.DeleteAsync(exercise);
        }

        /// <summary>
        /// Add Exercise if table database Exercise is empty
        /// </summary>
        /// <returns></returns>
        public async Task AddExercise()
        {
            ImageStorage imageStorage = new ImageStorage();
            List<Exercise> bodyParts = await GetExerciseAsync();
            if (bodyParts.Count == 0)
            {
                await SaveExerciseAsync(new Exercise { Name = "Pull Up", Source = "pullUp.gif", isEdit= false, BodyPartsExercise = "back | biceps | shoulders", Difficulty = "Facil", ColorDifficulty = "#32cd32", DateTime = DateTime.Now, Favorite = true, Description = "El pull-up es un ejercicio físico que consiste en elevar los hombros al nivel de una barra sujetándola con las manos. El objetivo principal de las dominadas es desarrollar los músculos de la espalda y los brazos. Es un ejercicio básico de entrenamiento de fuerza multiarticular que es muy popular porque es simple y efectivo. Existe una variante en la que el ejercicio se realiza de forma horizontal." });
                await SaveExerciseAsync(new Exercise { Name = "Push Up", Source = "pushUp.gif", isEdit = false, BodyPartsExercise = "pectorals | triceps | shoulders", Difficulty = "Easy", ColorDifficulty = "#32cd32", DateTime = DateTime.Now, Favorite = true, Description = "El push-up es un ejercicio de entrenamiento de fuerza que involucra principalmente al pectoral mayor, deltoides y tríceps. Este ejercicio es popular porque se puede realizar en cualquier lugar y no requiere equipo." });
                await SaveExerciseAsync(new Exercise { Name = "Dips", Source = "dips.gif", isEdit = false, BodyPartsExercise = "triceps | pectorals | shoulders", Difficulty = "Facil", ColorDifficulty = "#32cd32", DateTime = DateTime.Now, Favorite = true, Description = "Las barras dobles, también conocidas como fondos, son un ejercicio de entrenamiento de fuerza multiarticular diseñado para desarrollar fuerza y ​​volumen en los tríceps, pectorales y hombros (deltoides anterior)." });
                await SaveExerciseAsync(new Exercise { Name = "Squat", Source = "squat.gif", isEdit = false, BodyPartsExercise = "quadriceps | calves | ischios", Difficulty = "Facil", ColorDifficulty = "#32cd32", DateTime = DateTime.Now, Favorite = true, Description = "La sentadilla es un movimiento de musculación poliarticular útil para todos los deportes e ideal para trabajar toda la parte inferior del cuerpo. Los principales músculos implicados son los cuádriceps, los glúteos y los aductores." });
                await SaveExerciseAsync(new Exercise { Name = "Abs", Source = "abs.gif", isEdit = false, BodyPartsExercise = "abs", Difficulty = "Facil", ColorDifficulty = "#32cd32", DateTime = DateTime.Now, Favorite = true, Description = "El entrenamiento ABS (Abdominal Body System) se define como un programa de ejercicios destinado principalmente a exponer y desarrollar músculos abdominales fuertes." });

            }
        }
    }
}
