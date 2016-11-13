using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        private const string CreateStudentCommandName = "CreateStudentCommand";
        private const string CreateTeacherCommandName = "CreateTeacherCommand";
        private const string RemoveStudentCommandName = "RemoveStudentCommand";
        private const string RemoveTeacherCommandName = "RemoveTeacherCommand";
        private const string StudentListMarksCommandName = "StudentListMarksCommand";
        private const string TeacherAddMarkCommandName = "TeacherAddMarkCommand";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            this.Bind<IReader>().To<ConsoleReaderProvider>();
            this.Bind<IWriter>().To<ConsoleWriterProvider>();
            this.Bind<IParser>().To<CommandParserProvider>();
            this.Rebind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<ICommand>().To<CreateStudentCommand>().Named(CreateStudentCommandName);
            this.Bind<ICommand>().To<CreateTeacherCommand>().Named(CreateTeacherCommandName);
            this.Bind<ICommand>().To<RemoveStudentCommand>().Named(RemoveStudentCommandName);
            this.Bind<ICommand>().To<RemoveTeacherCommand>().Named(RemoveTeacherCommandName);
            this.Bind<ICommand>().To<StudentListMarksCommand>().Named(StudentListMarksCommandName);
            this.Bind<ICommand>().To<TeacherAddMarkCommand>().Named(TeacherAddMarkCommandName);

            this.Bind<Type>().ToMethod(context =>
            {
                ICommand createStudent = context.Kernel.Get<ICommand>(CreateStudentCommandName);
                ICommand removeStudent = context.Kernel.Get<ICommand>(RemoveStudentCommandName);
                ICommand createTeacher = context.Kernel.Get<ICommand>(CreateTeacherCommandName);
                ICommand removeTeacher = context.Kernel.Get<ICommand>(RemoveTeacherCommandName);
                ICommand studentListMarks = context.Kernel.Get<ICommand>(StudentListMarksCommandName);
                ICommand teacherAddMark = context.Kernel.Get<ICommand>(TeacherAddMarkCommandName);

                var currentAssembly = this.GetType()
                                       .GetTypeInfo()
                                       .Assembly;

                var commandTypeInfo = currentAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Command)))
                .Where(type => type.Name.ToLower().Contains(CreateStudentCommandName))
                .SingleOrDefault();

                if (commandTypeInfo == null)
                {
                    throw new ArgumentException("The passed command is not found!");
                }

                return commandTypeInfo;
            }).WhenInjectedInto<CommandParserProvider>();

            this.Bind<ICommandFactory>().ToFactory().InSingletonScope();
            this.Bind<IStudentFactory>().ToFactory().InSingletonScope();
            this.Bind<ITeacherFactory>().ToFactory().InSingletonScope();
            this.Bind<IMarkFactory>().ToFactory().InSingletonScope();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
            }
        }
    }
}