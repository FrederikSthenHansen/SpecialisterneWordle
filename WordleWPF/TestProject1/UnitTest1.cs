namespace TestProject1
{


    public class Tests
    {
        [SetUp]
    public void Setup()
    {
    }
    [Test]
    public void Test1()
    {
        WordleWPF.Model.GameMaster myGameMaster = new WordleWPF.Model.GameMaster();


        myGameMaster.newGame(false); ;

        Assert.Pass();
    }
    }
}