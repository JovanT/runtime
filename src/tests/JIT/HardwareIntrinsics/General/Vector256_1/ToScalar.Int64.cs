// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

/******************************************************************************
 * This file is auto-generated from a template file by the GenerateTests.csx  *
 * script in tests\src\JIT\HardwareIntrinsics\General\Shared. In order to make    *
 * changes, please update the corresponding template and run according to the *
 * directions listed in the file.                                             *
 ******************************************************************************/

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using Xunit;

namespace JIT.HardwareIntrinsics.General._Vector256_1
{
    public static partial class Program
    {
        [Fact]
        public static void ToScalarInt64()
        {
            var test = new VectorToScalar__ToScalarInt64();

            // Validates basic functionality works
            test.RunBasicScenario();

            // Validates calling via reflection works
            test.RunReflectionScenario();

            if (!test.Succeeded)
            {
                throw new Exception("One or more scenarios did not complete as expected.");
            }
        }
    }

    public sealed unsafe class VectorToScalar__ToScalarInt64
    {
        private static readonly int LargestVectorSize = 32;

        private static readonly int ElementCount = Unsafe.SizeOf<Vector256<Int64>>() / sizeof(Int64);

        public bool Succeeded { get; set; } = true;

        public void RunBasicScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunBasicScenario));

            Int64[] values = new Int64[ElementCount];

            for (int i = 0; i < ElementCount; i++)
            {
                values[i] = TestLibrary.Generator.GetInt64();
            }

            Vector256<Int64> value = Vector256.Create(values[0], values[1], values[2], values[3]);

            Int64 result = value.ToScalar();
            ValidateResult(result, values);
        }

        public void RunReflectionScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunReflectionScenario));

            Int64[] values = new Int64[ElementCount];

            for (int i = 0; i < ElementCount; i++)
            {
                values[i] = TestLibrary.Generator.GetInt64();
            }

            Vector256<Int64> value = Vector256.Create(values[0], values[1], values[2], values[3]);

            object result = typeof(Vector256)
                                .GetMethod(nameof(Vector256.ToScalar))
                                .MakeGenericMethod(typeof(Int64))
                                .Invoke(null, new object[] { value });

            ValidateResult((Int64)(result), values);
        }

        private void ValidateResult(Int64 result, Int64[] values, [CallerMemberName] string method = "")
        {
            if (result != values[0])
            {
                TestLibrary.TestFramework.LogInformation($"Vector256<Int64>.ToScalar(): {method} failed:");
                TestLibrary.TestFramework.LogInformation($"  values: ({string.Join(", ", values)})");
                TestLibrary.TestFramework.LogInformation($"  result: {result}");
                TestLibrary.TestFramework.LogInformation(string.Empty);

                Succeeded = false;
            }
        }
    }
}
