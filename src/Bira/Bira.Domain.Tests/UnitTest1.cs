using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Bira.Domain.Events;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Bira.Domain.Tests
{
    public class Sprint_Tests : Test_base
    {
        [Fact]
        public void When_the_last_task_is_removed_from_sprint_the_sprint_is_closed()
        {
            Given(
                Task_is_defined(Task_1),
                Task_is_defined(Task_2),
                Project_is_defined(Project_1),
                Sprint_is_planned(Project_1, Sprint_1),
                Task_is_committed_to_sprint(Sprint_1, Task_1),
                Task_is_committed_to_sprint(Sprint_1, Task_2),
                Task_is_removed_from_sprint(Sprint_1, Task_2)
            );

            When(
                Remove_task_from_sprint(Sprint_1, Task_1)
            );

            Then_expect(
                Task_is_removed_from_sprint(Sprint_1, Task_1),
                Sprint_is_closed(Sprint_1)
            );
        }

        [Fact]
        public void A_sprint_with_one_committed_task_can_be_started()
        {
            Given(
                Task_is_defined(Task_1),
                Project_is_defined(Project_1),
                Sprint_is_planned(Project_1, Sprint_1),
                Task_is_committed_to_sprint(Sprint_1, Task_1)
            );

            When(
                Start_sprint(Sprint_1));

            Then_expect(
                Sprint_is_started(Sprint_1));
        }

        [Fact]
        public void A_sprint_without_committed_tasks_cannot_be_started()
        {
            Given(
                Task_is_defined(Task_1),
                Project_is_defined(Project_1),
                Sprint_is_planned(Project_1, Sprint_1));
            No_tasks_committed_to_the_sprint(Sprint_1);

            When(
                Start_sprint(Sprint_1));

            Then_expect(
                Sprint_could_not_start(
                    Sprint_1,
                    Reason.No_tasks_in_sprint));
        }

        [Fact]
        public void Only_the_designated_sprint_should_start()
        {
            Given(
                Task_is_defined(Task_1),
                Task_is_defined(Task_2),
                Project_is_defined(Project_1),
                Sprint_is_planned(Project_1, Sprint_1),
                Sprint_is_planned(Project_1, Sprint_2),
                Task_is_committed_to_sprint(Sprint_1, Task_1),
                Task_is_committed_to_sprint(Sprint_2, Task_2)
            );

            When(
                Start_sprint(Sprint_1));

            Then_expect(
                Sprint_is_started(Sprint_1));
        }
    }
}