using DirManager;

namespace DirManager
{
    [TestClass]
    public class DirectoryManager_UnitTests
    {
        [TestMethod]
        public void DirectoryNode_TestBasics()
        {
            var cwd = new DirectoryManager();
            var depth = cwd.pathAsList.Count;
            var dir = new DirectoryNode(cwd);
            dir.PopulateAll();

            var rootDir = new DirectoryNode(cwd);
            rootDir.CdRoot();
            rootDir.PopulateAll();
        }

        //[Ignore]   // This test is very slow. Only activate it if needed.
        [TestMethod]
        public void DirectoryNode_SearchByFilter()
        {
            var aDrive = DirectoryNode.SetAtDriveLetterRoot("C");
            Assert.IsNotNull(aDrive);
            aDrive.CdDown("Windows");

            var results = aDrive.FindAll(".exe");
            Assert.IsTrue(results.Count > 1);
        }
    }
}