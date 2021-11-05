using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace apsys.training.bookstore.migrations
{
    public class Program
    {
        static int Main()
        {
            try
            {
                CommandLineArgs parameter = new CommandLineArgs();
                if (!parameter.ContainsKey("cnn"))
                    throw new ArgumentException("No [cnn] parameter received. You need pass the connection string in order to execute the migrations");

                string connectionString = parameter["cnn"];
                var serviceProvider = CreateServices(connectionString);
                using var scope = serviceProvider.CreateScope();
                UpdateDatabase(scope.ServiceProvider);
                return (int)ExitCode.Success;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error updating the database schema: {ex.Message}");
                Console.ResetColor();
                return (int)ExitCode.UnknownError;
            }
        }

        private static IServiceProvider CreateServices(string connectionString)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer2016()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(M01_CreateAuthorsTable).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

    }
    enum ExitCode
    {
        Success = 0,
        UnknownError = 1
    }

    class CommandLineArgs : Dictionary<string, string>
    {
        private const string Pattern = @"\/(?<argname>\w+):(?<argvalue>.+)";
        private readonly Regex _regex = new Regex(Pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public CommandLineArgs()
        {
            var args = Environment.GetCommandLineArgs();
            foreach (var match in args.Select(arg => _regex.Match(arg)).Where(m => m.Success))
                this.Add(match.Groups["argname"].Value, match.Groups["argvalue"].Value);
        }
    }
      
}
