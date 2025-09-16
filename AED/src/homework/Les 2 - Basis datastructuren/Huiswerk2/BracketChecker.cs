using System;

namespace AD
{
    public static class BracketChecker
    {

        /// <summary>
        ///    Run over all characters in a string, push all '(' characters
        ///    found on a stack. When ')' is found, it shoud match a '(' on
        ///    the stack, which is then popped.
        ///
        ///    If ')' is found when no '(' is on the stack, this method will
        ///    terminate prematurely, no further inspection is needed.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns>Returns True if all '(' are matched by ')'.
        /// Returns False otherwise.</returns>
        public static bool CheckBrackets(string s)
        {
            IMyStack<char> stack = new MyStack<char>();

            foreach (var ch in s)
            {
                if (ch == '(')
                {
                    stack.Push(ch);
                }
                else if (ch == ')')
                {
                    if (stack.IsEmpty())
                        return false;

                    stack.Pop();
                }
            }

            return stack.IsEmpty();
        }



        /// <summary>
        ///    Run over all characters in a string, when an opening bracket is
		///    found the closing counterpart from closeChar is pushed on a Stack
        ///    When an closing bracket is found, it should match the top character
		///    from this stack.
		///    
        ///    This method will terminate prematurely if a wrong or missmatched
        ///    closing bracket is found and no further inspection is needed.
		/// </summary>
		/// <param name="s">The string to check</param>
		/// <returns>Returns True if all opening brackets are matched by
		/// it's correct counterpart in a correct order.
        /// Returns False otherwise.</returns>
        public static bool CheckBrackets2(string s)
        {
            IMyStack<char> stack = new MyStack<char>();

            foreach (var ch in s)
            {
                // Opening brackets
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                // Closing brackets
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (stack.IsEmpty())
                        return false; // Closing without matching opening

                    var top = stack.Pop();

                    // Mismatch check
                    if ((ch == ')' && top != '(') ||
                        (ch == ']' && top != '[') ||
                        (ch == '}' && top != '{'))
                    {
                        return false;
                    }
                }
                // Ignore other characters if needed
            }

            // Stack must be empty at the end
            return stack.IsEmpty();
        }

    }

    class BracketCheckerInvalidInputException : Exception
    {
    }

}
