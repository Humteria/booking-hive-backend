using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

namespace BuildPipeline;

internal class Program
{
    static void Main(string[] args)
    {

        GithubPipeline githubPipeline = new()
        {
            Name = "BookingHive Backend Build Pipeline",

            OnEvents = new Events
            {
                PullRequest = new PullRequestEvent
                {
                    Branches = new string[] { "main" }
                },

                Push = new PushEvent
                {
                    Branches = new string[] { "main" }
                },
            },

            Jobs = new Jobs
            {
                Build = new BuildJob
                {
                    RunsOn = BuildMachines.UbuntuLatest,

                    Steps = new List<GithubTask>
            {
                new CheckoutTaskV2
                {
                    Name = "Checking Out Code"
                },

                new SetupDotNetTaskV1
                {
                    Name = "Installing .NET",

                    TargetDotNetVersion = new TargetDotNetVersion
                    {
                        DotNetVersion = "7.0.100"
                    }
                },

                new RestoreTask
                {
                    Name = "Restoring Nuget Packages",
                },

                new DotNetBuildTask
                {
                    Name = "Builduing Project"
                },

                new TestTask
                {
                    Name = "Running Tests"
                }
            }
                }
            }
        };

        string dirPath = "../../../../../.github/workflows";

        Directory.CreateDirectory(dirPath);

        ADotNetClient client = new();

        client.SerializeAndWriteToFile(
            adoPipeline: githubPipeline,
            path: Path.Combine(dirPath, "dotnet.yml")
        );

    }
}
