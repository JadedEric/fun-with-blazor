using BlazorApp.Domains;
using BlazorApp.Repositories;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.UnitTests
{
    public class QuestionRepositoryTest : MemoryDbContext
    {
        private QuestionRepository _questionRespository;

        [SetUp]
        public void Setup()
        {
            _questionRespository = new QuestionRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test, Order(0)]
        public async Task QuestionTableShouldBeCreatedSuccessfullyTest()
        {
            var questions = await _questionRespository.Get();
            Assert.False(questions.Any());
        }

        [Test, Order(1)]
        public async Task QuestionTableInsertedEntryShouldContainGeneratedIdTest()
        {
            var question = new Question
            {
                Name = "Question 1"
            };

            await _questionRespository.Post(question);
            await _context.SaveChangesAsync();

            Assert.NotNull(question.Id);
        }
    }
}
