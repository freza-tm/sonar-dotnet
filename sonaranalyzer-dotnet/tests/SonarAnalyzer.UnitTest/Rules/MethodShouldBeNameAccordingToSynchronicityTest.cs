﻿/*
 * SonarAnalyzer for .NET
 * Copyright (C) 2015-2018 SonarSource SA
 * mailto: contact AT sonarsource DOT com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

extern alias csharp;
using csharp::SonarAnalyzer.Rules.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SonarAnalyzer.UnitTest.Rules
{
    [TestClass]
    public class MethodShouldBeNameAccordingToSynchronicityTest
    {
        [TestMethod]
        [DataRow("4.0.0")]
        [DataRow(AssemblyReference.NuGetInfo.LatestVersion)]
        [TestCategory("Rule")]
        public void MethodShouldBeNameAccordingToSynchronicity(string tasksVersion)
        {
            Verifier.VerifyAnalyzer(@"TestCases\MethodShouldBeNameAccordingToSynchronicity.cs",
                new MethodShouldBeNameAccordingToSynchronicity(),
                null,
                AssemblyReference.FromNuGet("System.Threading.Tasks.Extensions.dll", "System.Threading.Tasks.Extensions", tasksVersion));
        }

        [DataTestMethod]
        [DataRow("1.1.11")]
        [DataRow(AssemblyReference.NuGetInfo.LatestVersion)]
        [TestCategory("Rule")]
        public void MethodShouldBeNameAccordingToSynchronicity_MsTest(string testFwkVersion)
        {
            Verifier.VerifyAnalyzer(@"TestCases\MethodShouldBeNameAccordingToSynchronicity.MsTest.cs",
                new MethodShouldBeNameAccordingToSynchronicity(),
                null,
                AssemblyReference.FromNuGet("Microsoft.VisualStudio.TestPlatform.TestFramework.dll", "MSTest.TestFramework", testFwkVersion),
                AssemblyReference.FromNuGet("System.Threading.Tasks.Extensions.dll", "System.Threading.Tasks.Extensions", "4.0.0"));
        }

        [DataTestMethod]
        [DataRow("2.5.7.10213")]
        [DataRow(AssemblyReference.NuGetInfo.LatestVersion)]
        [TestCategory("Rule")]
        public void MethodShouldBeNameAccordingToSynchronicity_NUnit(string testFwkVersion)
        {
            Verifier.VerifyAnalyzer(@"TestCases\MethodShouldBeNameAccordingToSynchronicity.NUnit.cs",
                new MethodShouldBeNameAccordingToSynchronicity(),
                null,
                AssemblyReference.FromNuGet("nunit.framework.dll", "NUnit", testFwkVersion),
                AssemblyReference.FromNuGet("System.Threading.Tasks.Extensions.dll", "System.Threading.Tasks.Extensions", "4.0.0"));
        }

        [DataTestMethod]
        [DataRow("2.0.0")]
        [DataRow(AssemblyReference.NuGetInfo.LatestVersion)]
        [TestCategory("Rule")]
        public void MethodShouldBeNameAccordingToSynchronicity_Xunit(string testFwkVersion)
        {
            Verifier.VerifyAnalyzer(@"TestCases\MethodShouldBeNameAccordingToSynchronicity.Xunit.cs",
                new MethodShouldBeNameAccordingToSynchronicity(),
                null,
                AssemblyReference.FromNuGet("xunit.assert.dll", "xunit.assert", testFwkVersion),
                AssemblyReference.FromNuGet("xunit.core.dll", "xunit.extensibility.core", testFwkVersion),
                AssemblyReference.FromNuGet("System.Threading.Tasks.Extensions.dll", "System.Threading.Tasks.Extensions", "4.0.0"));
        }
    }
}
