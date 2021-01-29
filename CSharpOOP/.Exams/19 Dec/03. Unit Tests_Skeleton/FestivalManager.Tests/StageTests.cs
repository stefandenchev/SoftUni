// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
        Performer perf;
        Performer perf10;
        Performer perfInvalid;
        Song song;
        Stage stage;
        TimeSpan ts = new TimeSpan(1500);

        [SetUp]
        public void Setup()
        {
            perf = new Performer("Stefan", "Denchev", 22);
            perf10 = new Performer("Tosho", "Toshev", 10);
            perfInvalid = new Performer("", "", 0);
            song = new Song("Hakuna Matata", ts);
            stage = new Stage();
        }
        [Test]
	    public void CheckPerformerCons()
	    {
            Performer perf2 = new Performer("Stefan", "Denchev", 22);
            Assert.AreEqual(perf.FullName, perf2.FullName);
            Assert.AreEqual(perf.Age, perf2.Age);
        }

        [Test]
        public void CheckPerfSongList()
        {
            perf.SongList.Add(song);
            Assert.AreEqual(perf.SongList.Count, 1);
        }

        [Test]
        public void CheckPerfStringOverride()
        {
            Assert.AreEqual(perf.ToString(), "Stefan Denchev");
        }

        [Test]
        public void CheckSongCons()
        {
            Song song2 = new Song("Hakuna Matata", ts);
            Assert.AreEqual(song.Duration, song2.Duration);
            Assert.AreEqual(song.Name, song2.Name);
        }

        [Test]
        public void CheckSongStringOverride()
        {
            Assert.AreEqual(song.ToString(), "Hakuna Matata (00:00)");
        }

        [Test]
        public void CheckStageAddPerf()
        {
            this.stage.AddPerformer(perf);
            Assert.AreEqual(this.stage.Performers.Count, 1);
        }

        [Test]
        public void CheckStageAddPerfException()
        {
            Assert.Throws<ArgumentException>(()
                => this.stage.AddPerformer(perf10));
        }

        [Test]
        public void CheckVariableNull()
        {
            Assert.Throws<ArgumentException>(()
                => this.stage.AddPerformer(perf10));
        }

    }
}