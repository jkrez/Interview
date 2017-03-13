﻿namespace Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class TestHelpers
    {
        // This is used instead of the ExpectedException test attribute to allow testing multiple exceptions
        // in the same test
        public static void AssertExceptionThrown(Action action, Type type)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            try
            {
                action();
            }
            catch (Exception e)
            {
                if (e.GetType() != type)
                {
                    Assert.Fail("Unexpected type of exception={0}", e.GetType());
                }

                return;
            }

            Assert.Fail("No exception thrown");
        }
    }
}