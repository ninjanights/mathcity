using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed;

public static class PracticeQuestionSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.PracticeQuestions.AnyAsync())
            return;

        var lessons = await context.Lessons
            .ToDictionaryAsync(l => l.Title);

        var questions = new List<PracticeQuestion>();

        void AddQuestion(
            string lessonTitle,
            string question,
            string optionA,
            string optionB,
            string optionC,
            string optionD,
            QuestionOption correctAnswer,
            string explanation,
            DifficultyLevel difficulty,
            int displayOrder)
        {
            questions.Add(new PracticeQuestion
            {
                LessonId = lessons[lessonTitle].Id,
                Question = question,
                OptionA = optionA,
                OptionB = optionB,
                OptionC = optionC,
                OptionD = optionD,
                CorrectAnswer = correctAnswer,
                Explanation = explanation,
                Difficulty = difficulty,
                DisplayOrder = displayOrder
            });
        }

       
        // Introduction to Algebraic Expressions
       
        AddQuestion(
            "Introduction to Algebraic Expressions",
            "Which of the following is an algebraic expression?",
            "5 + 3 = 8",
            "2x + 7",
            "10 > 6",
            "x = 5",
            QuestionOption.B,
            "An algebraic expression contains numbers, variables, and mathematical operations without an equality or inequality sign.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Algebraic Expressions",
            "In the expression 7x + 5, what is the coefficient of x?",
            "7",
            "5",
            "x",
            "12",
            QuestionOption.A,
            "The coefficient is the numerical factor multiplied by the variable. Here, 7 is multiplied by x.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Algebraic Expressions",
            "Which part of the expression 4y - 9 is the constant term?",
            "4",
            "y",
            "-9",
            "4y",
            QuestionOption.C,
            "A constant is a value without any variable attached. In 4y - 9, the constant is -9.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Algebraic Expressions",
            "How many terms are there in the expression 3a + 2b - 5?",
            "2",
            "3",
            "4",
            "5",
            QuestionOption.B,
            "The terms are 3a, 2b, and -5, making a total of three terms.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Algebraic Expressions",
            "Which statement best describes an algebraic expression?",
            "It always contains an equal sign.",
            "It is made up of variables, constants, and operations.",
            "It can only contain numbers.",
            "It always has exactly one variable.",
            QuestionOption.B,
            "An algebraic expression combines variables, constants, and mathematical operations without requiring an equality sign.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Simplifying and Evaluating Algebraic Expressions
        // ==========================================================

        AddQuestion(
            "Simplifying and Evaluating Algebraic Expressions",
            "What is the simplified form of 3x + 2x?",
            "5x",
            "6x",
            "5",
            "x²",
            QuestionOption.A,
            "Like terms can be combined by adding their coefficients. 3x + 2x = 5x.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Simplifying and Evaluating Algebraic Expressions",
            "Simplify: 4a + 3 - 2a + 5",
            "6a + 8",
            "2a + 8",
            "2a + 2",
            "6a + 2",
            QuestionOption.B,
            "Combine like terms: 4a - 2a = 2a and 3 + 5 = 8, giving 2a + 8.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Simplifying and Evaluating Algebraic Expressions",
            "Evaluate 2x + 5 when x = 3.",
            "8",
            "10",
            "11",
            "13",
            QuestionOption.C,
            "Substitute x = 3: 2(3) + 5 = 6 + 5 = 11.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Simplifying and Evaluating Algebraic Expressions",
            "Which expression is equivalent to 5(x + 2)?",
            "5x + 2",
            "5x + 10",
            "x + 10",
            "5x + 5",
            QuestionOption.B,
            "Using the distributive property: 5(x + 2) = 5x + 10.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Simplifying and Evaluating Algebraic Expressions",
            "Why is simplifying algebraic expressions important?",
            "It makes expressions easier to understand, compare, and solve.",
            "It removes all variables from mathematics.",
            "It only works for numbers without variables.",
            "It changes equations into shapes.",
            QuestionOption.A,
            "Simplification reduces complex expressions into simpler forms, making further calculations and problem-solving easier.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Algebraic Expressions
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Algebraic Expressions",
            "A pencil costs ₹x and a notebook costs ₹20. Which expression represents the total cost of 3 pencils and 2 notebooks?",
            "3x + 20",
            "3x + 40",
            "5x + 20",
            "3(x + 20)",
            QuestionOption.B,
            "The cost of 3 pencils is 3x and the cost of 2 notebooks is 2 × 20 = 40, so the total is 3x + 40.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Algebraic Expressions",
            "If the length of a rectangle is x + 5 and the width is x, which expression represents its perimeter?",
            "2x + 5",
            "x² + 5",
            "4x + 10",
            "2x + 10",
            QuestionOption.C,
            "Perimeter of a rectangle = 2(length + width). So 2((x + 5) + x) = 2(2x + 5) = 4x + 10.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Algebraic Expressions",
            "A student has x books and receives 7 more books. Which expression represents the new number of books?",
            "x - 7",
            "7x",
            "x + 7",
            "x ÷ 7",
            QuestionOption.C,
            "Receiving 7 more books means adding 7 to the original number, giving x + 7.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Algebraic Expressions",
            "The cost of a trip is represented by 50 + 10d, where d is the number of days. What does 10d represent?",
            "The fixed starting cost",
            "The cost added for each day",
            "The total number of days",
            "A variable with no meaning",
            QuestionOption.B,
            "10d represents the daily cost multiplied by the number of days.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Algebraic Expressions",
            "Why are algebraic expressions useful in real-world situations?",
            "They help represent unknown values and relationships using mathematical models.",
            "They only work for classroom exercises.",
            "They remove the need for calculations.",
            "They cannot represent real situations.",
            QuestionOption.A,
            "Algebraic expressions allow us to model situations involving costs, distances, quantities, and changing values.",
            DifficultyLevel.Advance,
            5);


        // Introduction to Linear Equations


        AddQuestion(
            "Introduction to Linear Equations",
            "Which of the following is a linear equation?",
            "x² + 3 = 7",
            "2x + 5 = 11",
            "x³ - 1 = 0",
            "√x = 4",
            QuestionOption.B,
            "A linear equation has the highest power of the variable equal to 1. Therefore, 2x + 5 = 11 is a linear equation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Linear Equations",
            "What is the highest exponent of the variable in a linear equation?",
            "0",
            "1",
            "2",
            "3",
            QuestionOption.B,
            "A linear equation is defined by having the highest exponent of every variable equal to 1.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Linear Equations",
            "Which equation is in the standard form of a linear equation in one variable?",
            "ax + b = 0",
            "ax² + bx + c = 0",
            "a/x = b",
            "x³ + 1 = 0",
            QuestionOption.A,
            "The standard form of a linear equation in one variable is ax + b = 0, where a ≠ 0.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Linear Equations",
            "What is the solution of a linear equation?",
            "The coefficient of the variable",
            "The value of the variable that satisfies the equation",
            "The constant term",
            "The highest exponent",
            QuestionOption.B,
            "A solution is the value of the variable that makes both sides of the equation equal.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Linear Equations",
            "Why are linear equations widely used in mathematics and real-life applications?",
            "They only work with whole numbers.",
            "They model relationships between variables and help solve practical problems.",
            "They always have more than one solution.",
            "They cannot be represented graphically.",
            QuestionOption.B,
            "Linear equations are used to represent relationships between quantities and are widely applied in science, engineering, economics, and everyday problem-solving.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Solving Linear Equations
        // ==========================================================

        AddQuestion(
            "Solving Linear Equations",
            "Solve: x + 5 = 12",
            "x = 5",
            "x = 7",
            "x = 12",
            "x = 17",
            QuestionOption.B,
            "Subtract 5 from both sides: x + 5 - 5 = 12 - 5, so x = 7.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Linear Equations",
            "Solve: 3x = 15",
            "x = 3",
            "x = 5",
            "x = 10",
            "x = 45",
            QuestionOption.B,
            "Divide both sides by 3: 3x ÷ 3 = 15 ÷ 3, so x = 5.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Linear Equations",
            "Solve: 2x + 4 = 10",
            "x = 2",
            "x = 3",
            "x = 4",
            "x = 7",
            QuestionOption.B,
            "Subtract 4 from both sides: 2x = 6. Divide by 2: x = 3.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Linear Equations",
            "Which method is used to keep both sides of an equation balanced while solving?",
            "Changing the answer randomly",
            "Performing the same operation on both sides",
            "Removing variables without calculation",
            "Ignoring numbers on one side",
            QuestionOption.B,
            "The balance method requires applying the same operation to both sides so the equation remains equal.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Linear Equations",
            "Why are linear equations useful in real-world problems?",
            "They help model relationships involving unknown values such as cost, distance, and time.",
            "They only solve geometry problems.",
            "They cannot represent real situations.",
            "They remove the need for variables.",
            QuestionOption.A,
            "Linear equations are used to represent and solve problems involving relationships between quantities.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Linear Equations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Linear Equations",
            "A taxi charges a fixed fee of ₹50 and ₹10 per kilometer. Which equation represents the total cost C for k kilometers?",
            "C = 50k + 10",
            "C = 50 + 10k",
            "C = 10 + k",
            "C = 50 - 10k",
            QuestionOption.B,
            "The fixed fee is ₹50 and the additional cost is ₹10 multiplied by the number of kilometers, so C = 50 + 10k.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Linear Equations",
            "A student has ₹100 and saves ₹20 every week. Which equation represents the total money M after w weeks?",
            "M = 100 + 20w",
            "M = 100w + 20",
            "M = 20 - 100w",
            "M = 100 - 20",
            QuestionOption.A,
            "The starting amount is ₹100 and ₹20 is added each week, giving M = 100 + 20w.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Linear Equations",
            "A car travels at a constant speed of 60 km/h. Which equation represents distance d after t hours?",
            "d = 60 + t",
            "d = 60t",
            "d = t ÷ 60",
            "d = 60 - t",
            QuestionOption.B,
            "Distance = speed × time, so d = 60t.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Linear Equations",
            "A phone plan costs ₹200 per month plus ₹5 per GB of data used. If the total bill is ₹350, how many GB were used?",
            "20 GB",
            "30 GB",
            "40 GB",
            "50 GB",
            QuestionOption.B,
            "The equation is 200 + 5x = 350. Subtract 200: 5x = 150. Divide by 5: x = 30 GB.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Linear Equations",
            "Why are linear equations useful for modelling real-world situations?",
            "They represent relationships between changing quantities and help predict unknown values.",
            "They only work with numbers without variables.",
            "They cannot describe real-life relationships.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Linear equations are widely used in finance, science, engineering, business, and everyday decision-making to model relationships between quantities.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Simultaneous Equations
        // ==========================================================

        AddQuestion(
            "Introduction to Simultaneous Equations",
            "What are simultaneous equations?",
            "Two or more equations solved together to find common unknown values",
            "Equations containing only one variable",
            "Equations with exponents greater than one",
            "Equations without variables",
            QuestionOption.A,
            "Simultaneous equations consist of two or more equations that share the same variables and are solved together.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Simultaneous Equations",
            "Why are simultaneous equations solved together?",
            "To simplify fractions",
            "To find values that satisfy all the equations at the same time",
            "To remove variables permanently",
            "To convert equations into inequalities",
            QuestionOption.B,
            "The solution must satisfy every equation in the system simultaneously.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Simultaneous Equations",
            "A pair of simultaneous equations with two variables usually has how many unknowns?",
            "One",
            "Two",
            "Three",
            "Four",
            QuestionOption.B,
            "A typical system contains two unknown variables, such as x and y.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Simultaneous Equations",
            "Which of the following is an example of simultaneous equations?",
            "x + 2 = 5",
            "x² + y² = 25",
            "2x + y = 7 and x - y = 1",
            "5 > 3",
            QuestionOption.C,
            "A system of simultaneous equations contains two or more equations involving the same variables.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Simultaneous Equations",
            "Where are simultaneous equations commonly used?",
            "Only in geometry",
            "Only in accounting",
            "To model and solve problems involving multiple unknown quantities",
            "Only for calculating percentages",
            QuestionOption.C,
            "Simultaneous equations are widely used in science, engineering, economics, and everyday situations where multiple unknowns must be determined.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Methods for Solving Simultaneous Equations
        // ==========================================================

        AddQuestion(
            "Methods for Solving Simultaneous Equations",
            "Which method involves replacing one variable with an expression from another equation?",
            "Elimination method",
            "Substitution method",
            "Graphical method",
            "Factorization method",
            QuestionOption.B,
            "The substitution method solves simultaneous equations by expressing one variable in terms of another and substituting it into the second equation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Methods for Solving Simultaneous Equations",
            "Which method eliminates one variable by adding or subtracting equations?",
            "Substitution",
            "Graphical",
            "Elimination",
            "Division",
            QuestionOption.C,
            "The elimination method combines equations to cancel one variable and find the remaining unknown.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Methods for Solving Simultaneous Equations",
            "Solve using elimination: x + y = 10 and x - y = 2. What is the value of x?",
            "4",
            "5",
            "6",
            "8",
            QuestionOption.C,
            "Adding both equations gives 2x = 12, so x = 6.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Methods for Solving Simultaneous Equations",
            "In the graphical method, what represents the solution of two simultaneous equations?",
            "The point where both lines intersect",
            "The highest point on a line",
            "The y-axis only",
            "The distance between lines",
            QuestionOption.A,
            "The intersection point of two graphs represents the values of x and y that satisfy both equations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Methods for Solving Simultaneous Equations",
            "Why are different methods used for solving simultaneous equations?",
            "Different methods provide efficient ways to solve systems depending on the form of equations.",
            "Each method gives a different answer.",
            "Only one method is mathematically correct.",
            "Methods are used only for drawing graphs.",
            QuestionOption.A,
            "Substitution, elimination, and graphical methods are different approaches that help solve systems efficiently.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Simultaneous Equations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Simultaneous Equations",
            "A notebook costs ₹x and a pen costs ₹y. If 2 notebooks and 3 pens cost ₹160, which equation represents this situation?",
            "2x + 3y = 160",
            "x + y = 160",
            "2x - 3y = 160",
            "x × y = 160",
            QuestionOption.A,
            "The total cost is found by multiplying each item's price by its quantity and adding them together.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Simultaneous Equations",
            "Two numbers have a sum of 20 and their difference is 4. Which pair represents these numbers?",
            "8 and 12",
            "10 and 10",
            "5 and 15",
            "6 and 14",
            QuestionOption.A,
            "Let the numbers be x and y. Solving x + y = 20 and x - y = 4 gives x = 12 and y = 8.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Simultaneous Equations",
            "A farm has chickens and cows. There are 20 animals and 56 legs in total. How many cows are there?",
            "6",
            "8",
            "10",
            "12",
            QuestionOption.B,
            "Let chickens = x and cows = y. x + y = 20 and 2x + 4y = 56. Solving gives y = 8 cows.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Simultaneous Equations",
            "Why are simultaneous equations useful in real-life problems?",
            "They help find unknown values when multiple conditions are connected.",
            "They only solve single-variable problems.",
            "They are only used for drawing graphs.",
            "They cannot represent real situations.",
            QuestionOption.A,
            "Many real-world problems involve multiple unknown quantities that are related through different conditions.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Simultaneous Equations",
            "Which field commonly uses simultaneous equations for solving complex problems?",
            "Engineering and economics",
            "Only handwriting practice",
            "Only basic counting",
            "Only shape drawing",
            QuestionOption.A,
            "Engineers, economists, scientists, and analysts use simultaneous equations to model relationships between multiple variables.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Inequalities
        // ==========================================================

        AddQuestion(
            "Introduction to Inequalities",
            "What is the primary purpose of an inequality?",
            "To show that two expressions are always equal",
            "To compare two quantities using inequality symbols",
            "To find the square root of a number",
            "To simplify algebraic expressions",
            QuestionOption.B,
            "An inequality compares two quantities and shows whether one is greater than, less than, greater than or equal to, or less than or equal to the other.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Inequalities",
            "Which symbol represents 'greater than'?",
            "<",
            ">",
            "=",
            "≠",
            QuestionOption.B,
            "The symbol '>' means that the value on the left is greater than the value on the right.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Inequalities",
            "Which of the following is an inequality?",
            "4x + 2 = 10",
            "5 + 3 = 8",
            "2x - 1 ≥ 7",
            "3 × 4 = 12",
            QuestionOption.C,
            "An inequality uses symbols such as <, >, ≤, or ≥ instead of the equality sign.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Inequalities",
            "Which symbol means 'less than or equal to'?",
            "<",
            "≤",
            "≥",
            ">",
            QuestionOption.B,
            "The symbol '≤' indicates that a value is either less than or equal to another value.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Inequalities",
            "Why are inequalities useful in mathematics and real-life situations?",
            "They are only used to solve geometry problems.",
            "They help compare quantities and describe limits or ranges of possible values.",
            "They can only compare whole numbers.",
            "They always have exactly one solution.",
            QuestionOption.B,
            "Inequalities are used to represent conditions, limits, and ranges in areas such as budgeting, science, engineering, and optimization problems.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Solving and Graphing Inequalities
        // ==========================================================

        AddQuestion(
            "Solving and Graphing Inequalities",
            "Solve: x + 3 > 7",
            "x > 3",
            "x > 4",
            "x < 4",
            "x < 3",
            QuestionOption.B,
            "Subtract 3 from both sides: x + 3 - 3 > 7 - 3, so x > 4.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving and Graphing Inequalities",
            "Which symbol represents 'less than or equal to'?",
            ">",
            "<",
            "≥",
            "≤",
            QuestionOption.D,
            "The symbol ≤ means a value is less than or equal to another value.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving and Graphing Inequalities",
            "Solve: 2x ≤ 10",
            "x ≤ 2",
            "x ≤ 5",
            "x ≥ 5",
            "x ≥ 2",
            QuestionOption.B,
            "Divide both sides by 2: 2x ÷ 2 ≤ 10 ÷ 2, so x ≤ 5.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving and Graphing Inequalities",
            "What happens when an inequality is divided by a negative number?",
            "The inequality sign reverses direction",
            "The inequality disappears",
            "The answer becomes zero",
            "The variable is removed",
            QuestionOption.A,
            "When multiplying or dividing both sides of an inequality by a negative number, the inequality sign must be reversed.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving and Graphing Inequalities",
            "Why are inequalities represented on number lines?",
            "They show a range of possible solutions instead of a single value.",
            "They remove the need for solving.",
            "They only show positive numbers.",
            "They are used only for equations.",
            QuestionOption.A,
            "Unlike equations that usually have specific solutions, inequalities represent sets or ranges of values.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Inequalities
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Inequalities",
            "A student must score at least 50 marks to pass an exam. Which inequality represents this situation if x is the student's score?",
            "x < 50",
            "x > 50",
            "x ≥ 50",
            "x ≤ 50",
            QuestionOption.C,
            "The phrase 'at least 50' means the score can be 50 or more, so x ≥ 50.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Inequalities",
            "A bus can carry a maximum of 40 passengers. Which inequality represents the number of passengers p?",
            "p ≥ 40",
            "p ≤ 40",
            "p = 40",
            "p > 40",
            QuestionOption.B,
            "Maximum means the number cannot exceed 40, so p ≤ 40.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Inequalities",
            "A mobile data plan allows up to 20 GB of data usage. If x represents used data, which inequality is correct?",
            "x < 20",
            "x ≤ 20",
            "x ≥ 20",
            "x = 20",
            QuestionOption.B,
            "Up to 20 GB means the usage can be 20 or any smaller amount, so x ≤ 20.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Inequalities",
            "A shopkeeper wants to spend less than ₹500 on supplies. Which inequality represents the spending amount s?",
            "s > 500",
            "s < 500",
            "s ≥ 500",
            "s = 500",
            QuestionOption.B,
            "The phrase 'less than ₹500' means the amount must be smaller than 500, so s < 500.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Inequalities",
            "Why are inequalities useful for solving real-world problems?",
            "They help represent limits, conditions, and possible ranges of values.",
            "They only work with exact answers.",
            "They cannot represent practical situations.",
            "They are only used for drawing graphs.",
            QuestionOption.A,
            "Inequalities are used in budgeting, engineering limits, speed restrictions, capacity problems, and many other situations where ranges matter.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Quadratic Equations
        // ==========================================================

        AddQuestion(
            "Introduction to Quadratic Equations",
            "What is the standard form of a quadratic equation?",
            "ax + b = 0",
            "ax² + bx + c = 0",
            "a + b + c = 0",
            "x² + x = 1",
            QuestionOption.B,
            "A quadratic equation is written in the standard form ax² + bx + c = 0, where a is not equal to zero.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Quadratic Equations",
            "What is the highest power of the variable in a quadratic equation?",
            "1",
            "2",
            "3",
            "4",
            QuestionOption.B,
            "Quadratic equations contain a variable raised to the power of 2, which is why they are called quadratic.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Quadratic Equations",
            "Which part of the equation ax² + bx + c = 0 is the quadratic term?",
            "a",
            "bx",
            "ax²",
            "c",
            QuestionOption.C,
            "The term ax² is the quadratic term because it contains the variable with exponent 2.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Quadratic Equations",
            "How are quadratic equations different from linear equations?",
            "Quadratic equations have a squared variable term, while linear equations have only a first-degree variable.",
            "Quadratic equations have no variables.",
            "Linear equations always have x² terms.",
            "There is no difference between them.",
            QuestionOption.A,
            "Linear equations have degree 1, while quadratic equations have degree 2 because of the x² term.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Quadratic Equations",
            "Why are quadratic equations important in mathematics and real-world applications?",
            "They help model situations involving areas, motion, optimization, and many scientific problems.",
            "They are only used for simple calculations.",
            "They cannot represent real situations.",
            "They are only used for naming shapes.",
            QuestionOption.A,
            "Quadratic equations are used in physics, engineering, economics, architecture, and many other fields to model curved relationships.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Methods for Solving Quadratic Equations
        // ==========================================================

        AddQuestion(
            "Methods for Solving Quadratic Equations",
            "Which method solves a quadratic equation by expressing it as a product of two factors?",
            "Graphing",
            "Factorization",
            "Substitution",
            "Division",
            QuestionOption.B,
            "Factorization involves rewriting a quadratic expression as a product of two or more factors and finding the values that make each factor zero.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Methods for Solving Quadratic Equations",
            "What is the quadratic formula used for?",
            "To solve quadratic equations of the form ax² + bx + c = 0",
            "To solve only linear equations",
            "To calculate areas of shapes",
            "To simplify fractions only",
            QuestionOption.A,
            "The quadratic formula provides solutions for any quadratic equation where a is not zero.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Methods for Solving Quadratic Equations",
            "Which expression appears inside the square root of the quadratic formula?",
            "a + b + c",
            "b² - 4ac",
            "2a + b",
            "x² + y²",
            QuestionOption.B,
            "The expression b² - 4ac is called the discriminant and determines the nature of the roots.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Methods for Solving Quadratic Equations",
            "What is the purpose of completing the square method?",
            "To rewrite a quadratic equation into a perfect square form",
            "To remove all variables",
            "To convert it into a linear equation",
            "To multiply both sides randomly",
            QuestionOption.A,
            "Completing the square transforms a quadratic expression into a form that can be solved using square roots.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Methods for Solving Quadratic Equations",
            "Why is it useful to have multiple methods for solving quadratic equations?",
            "Different methods are suitable for different equations and problem situations.",
            "Each method always gives a different answer.",
            "Only one method is mathematically valid.",
            "Methods are used only for graph drawing.",
            QuestionOption.A,
            "Factorization, completing the square, and the quadratic formula provide different approaches depending on the structure of the equation.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Quadratic Equations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Quadratic Equations",
            "A ball is thrown upward and its height is represented by h = -5t² + 20t. What type of equation represents this situation?",
            "Linear equation",
            "Quadratic equation",
            "Constant equation",
            "Fraction equation",
            QuestionOption.B,
            "The equation contains t², making it a quadratic equation. Quadratic equations are commonly used to model projectile motion.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Quadratic Equations",
            "Why are quadratic equations used to model projectile motion?",
            "Because the height changes in a curved path due to gravity.",
            "Because motion always follows a straight line.",
            "Because they cannot contain variables.",
            "Because they only represent fixed values.",
            QuestionOption.A,
            "Objects thrown into the air follow a parabolic path, which can be represented using quadratic equations.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Quadratic Equations",
            "The area of a rectangular garden is represented by x(x + 5) = 150. Why can this be solved using a quadratic equation?",
            "Because multiplying the expressions creates an x² term.",
            "Because it contains no variables.",
            "Because it is always a linear equation.",
            "Because area cannot be calculated.",
            QuestionOption.A,
            "Expanding x(x + 5) gives x² + 5x = 150, which is a quadratic equation.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Quadratic Equations",
            "What does the graph of a quadratic equation look like?",
            "A parabola",
            "A straight line",
            "A circle",
            "A rectangle",
            QuestionOption.A,
            "The graph of a quadratic equation forms a parabola, which can open upward or downward depending on the coefficient of x².",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Quadratic Equations",
            "Why are quadratic equations important in real-world applications?",
            "They help solve problems involving optimization, motion, area, and changing relationships.",
            "They are only used for basic arithmetic.",
            "They cannot represent practical situations.",
            "They are only useful for drawing graphs.",
            QuestionOption.A,
            "Quadratic equations are widely used in physics, engineering, economics, architecture, and computer science for modelling complex relationships.",
            DifficultyLevel.Advance,
            5);




        // ==========================================================
        // Introduction to Polynomials
        // ==========================================================

        AddQuestion(
            "Introduction to Polynomials",
            "What is a polynomial?",
            "An algebraic expression made up of variables, constants, and non-negative integer exponents",
            "An equation that always contains an equal sign",
            "An expression containing variables only",
            "A mathematical expression with negative exponents only",
            QuestionOption.A,
            "A polynomial is an algebraic expression consisting of variables, constants, and non-negative integer exponents combined using addition, subtraction, and multiplication.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Polynomials",
            "Which of the following is a polynomial?",
            "3x² + 2x - 5",
            "5/x + 2",
            "√x + 4",
            "2x⁻¹ + 3",
            QuestionOption.A,
            "A polynomial cannot have variables in denominators, radicals, or negative exponents. Therefore, 3x² + 2x - 5 is a polynomial.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Polynomials",
            "What is the degree of the polynomial 4x³ + 2x - 7?",
            "1",
            "2",
            "3",
            "4",
            QuestionOption.C,
            "The degree of a polynomial is the highest exponent of its variable. Here, the highest exponent is 3.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Polynomials",
            "What is the standard form of a polynomial?",
            "Terms arranged from the lowest degree to the highest",
            "Terms arranged in any order",
            "Terms arranged from the highest degree to the lowest",
            "Only constant terms written together",
            QuestionOption.C,
            "The standard form of a polynomial arranges terms in descending order of their degrees.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Polynomials",
            "Why are polynomials important in mathematics and science?",
            "They are only used for school examinations.",
            "They are used to model relationships, solve equations, and represent real-world phenomena.",
            "They can only represent straight lines.",
            "They are only applicable in geometry.",
            QuestionOption.B,
            "Polynomials are widely used in algebra, calculus, physics, engineering, economics, computer graphics, and many other fields to model and solve real-world problems.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Polynomial Operations and Factorization
        // ==========================================================

        AddQuestion(
            "Polynomial Operations and Factorization",
            "What is the result of adding 3x² + 2x and 5x² + 4x?",
            "8x² + 6x",
            "15x² + 8x",
            "8x² + 8",
            "2x² + 2x",
            QuestionOption.A,
            "Add like terms: 3x² + 5x² = 8x² and 2x + 4x = 6x.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Polynomial Operations and Factorization",
            "Simplify: (4x² + 3x) - (2x² + x)",
            "2x² + 2x",
            "6x² + 4x",
            "2x² + 4x",
            "6x² + 2x",
            QuestionOption.A,
            "Subtract corresponding terms: 4x² - 2x² = 2x² and 3x - x = 2x.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Polynomial Operations and Factorization",
            "Which method is used to rewrite a polynomial as a product of simpler expressions?",
            "Expansion",
            "Factorization",
            "Addition",
            "Division",
            QuestionOption.B,
            "Factorization breaks a polynomial into factors that multiply together to give the original expression.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Polynomial Operations and Factorization",
            "Factorize: x² + 5x + 6",
            "(x + 2)(x + 3)",
            "(x + 1)(x + 6)",
            "(x + 5)(x + 6)",
            "(x + 2)(x + 4)",
            QuestionOption.A,
            "Find two numbers whose product is 6 and sum is 5. These are 2 and 3, so x² + 5x + 6 = (x + 2)(x + 3).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Polynomial Operations and Factorization",
            "Why are polynomial operations and factorization important?",
            "They simplify expressions and help solve mathematical problems involving variables.",
            "They only apply to numbers without variables.",
            "They remove the need for calculations.",
            "They are only used for drawing graphs.",
            QuestionOption.A,
            "Polynomial operations are essential in algebra, calculus, physics, engineering, and many mathematical applications.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Polynomials
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Polynomials",
            "The area of a rectangle is represented by x² + 5x + 6. Which polynomial form represents its factored dimensions?",
            "(x + 2)(x + 3)",
            "(x + 1)(x + 6)",
            "(x + 5)(x + 6)",
            "(x + 2)(x + 4)",
            QuestionOption.A,
            "Factoring x² + 5x + 6 gives (x + 2)(x + 3), which can represent the length and width of the rectangle.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Polynomials",
            "A company models its profit using a polynomial function. Why are polynomials useful in such situations?",
            "They can represent changing relationships between quantities.",
            "They only represent fixed numbers.",
            "They cannot include variables.",
            "They are only used for geometry.",
            QuestionOption.A,
            "Polynomial functions can model real-world changes such as profit, growth, motion, and cost relationships.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Polynomials",
            "If a polynomial function gives the height of an object over time, what can its graph help determine?",
            "Important values such as maximum height and when the object reaches certain positions.",
            "Only the colour of the object.",
            "The object's weight only.",
            "The number of variables used.",
            QuestionOption.A,
            "Graphs of polynomial functions help analyze behaviour, turning points, intercepts, and changes over time.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Polynomials",
            "Which operation is commonly used to simplify polynomial expressions before solving problems?",
            "Combining like terms",
            "Changing variables randomly",
            "Removing all coefficients",
            "Ignoring negative values",
            QuestionOption.A,
            "Combining like terms reduces polynomial expressions into simpler forms.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Polynomials",
            "Why are polynomial concepts important in advanced mathematics and science?",
            "They are used to model complex systems in engineering, physics, computing, and data analysis.",
            "They are only useful for basic calculations.",
            "They cannot describe real-world patterns.",
            "They are unrelated to scientific fields.",
            QuestionOption.A,
            "Polynomials are fundamental tools used in many fields to approximate and analyze real-world phenomena.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Factorization
        // ==========================================================

        AddQuestion(
            "Introduction to Factorization",
            "What is factorization?",
            "The process of expanding an expression",
            "The process of writing an expression as a product of simpler factors",
            "The process of adding like terms",
            "The process of solving an equation",
            QuestionOption.B,
            "Factorization is the process of expressing an algebraic expression as the product of two or more simpler factors.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Factorization",
            "Why is factorization important in algebra?",
            "It makes expressions more complicated.",
            "It helps simplify expressions and solve equations more efficiently.",
            "It is only used in geometry.",
            "It replaces variables with constants.",
            QuestionOption.B,
            "Factorization simplifies algebraic expressions and is an essential technique for solving equations and understanding mathematical relationships.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Factorization",
            "Which of the following is a factor of the expression 6x?",
            "2x",
            "6x²",
            "x + 6",
            "6 + x",
            QuestionOption.A,
            "Since 6x = 2x × 3, 2x is a factor of 6x.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Factorization",
            "What is the opposite process of factorization?",
            "Division",
            "Expansion",
            "Substitution",
            "Simplification",
            QuestionOption.B,
            "Expansion multiplies factors together to produce an algebraic expression, making it the opposite of factorization.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Factorization",
            "In which area is factorization commonly applied?",
            "Only in arithmetic",
            "Only in statistics",
            "Solving equations, simplifying expressions, and higher mathematics",
            "Only in geometry",
            QuestionOption.C,
            "Factorization is a fundamental tool used throughout algebra, calculus, engineering, computer science, and many other mathematical disciplines.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Methods of Factorization
        // ==========================================================

        AddQuestion(
            "Methods of Factorization",
            "What is the first step when factoring an algebraic expression using the common factor method?",
            "Find the greatest common factor of all terms",
            "Multiply all terms together",
            "Remove all variables",
            "Convert it into a graph",
            QuestionOption.A,
            "The common factor method begins by identifying the greatest factor shared by all terms and taking it outside the brackets.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Methods of Factorization",
            "Factorize: 6x + 12",
            "6(x + 2)",
            "3(2x + 12)",
            "2(3x + 12)",
            "6(x + 12)",
            QuestionOption.A,
            "The greatest common factor of 6x and 12 is 6, so 6x + 12 = 6(x + 2).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Methods of Factorization",
            "Which identity is used to factorize a² - b²?",
            "(a + b)²",
            "(a - b)(a + b)",
            "a² + b²",
            "(a + b)(a + b)",
            QuestionOption.B,
            "The difference of squares identity states that a² - b² = (a - b)(a + b).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Methods of Factorization",
            "Which method is commonly used to factorize expressions with four terms by grouping them?",
            "Grouping method",
            "Division method",
            "Graphing method",
            "Substitution method",
            QuestionOption.A,
            "The grouping method separates terms into groups and finds common factors from each group.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Methods of Factorization",
            "Why is factorization important in algebra?",
            "It simplifies expressions and helps solve equations by breaking them into simpler factors.",
            "It removes all mathematical operations.",
            "It only changes numbers into decimals.",
            "It is only useful for drawing graphs.",
            QuestionOption.A,
            "Factorization is used extensively in solving equations, simplifying expressions, and understanding algebraic structures.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Factorization
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Factorization",
            "Factorize x² + 7x + 12.",
            "(x + 3)(x + 4)",
            "(x + 2)(x + 6)",
            "(x + 1)(x + 12)",
            "(x + 5)(x + 7)",
            QuestionOption.A,
            "Find two numbers whose product is 12 and sum is 7. The numbers are 3 and 4, so x² + 7x + 12 = (x + 3)(x + 4).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Factorization",
            "A rectangular garden has an area represented by x² + 10x + 24. Which expression represents its possible dimensions?",
            "(x + 4)(x + 6)",
            "(x + 2)(x + 12)",
            "(x + 1)(x + 24)",
            "(x + 5)(x + 5)",
            QuestionOption.A,
            "Factorizing x² + 10x + 24 gives (x + 4)(x + 6), which can represent the length and width.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Factorization",
            "Solve the equation x² - 9 = 0 using factorization.",
            "x = 3 only",
            "x = -3 only",
            "x = ±3",
            "x = 9",
            QuestionOption.C,
            "Using difference of squares: x² - 9 = (x - 3)(x + 3). Therefore, x = 3 or x = -3.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Factorization",
            "Which real-world area commonly uses factorization?",
            "Engineering and mathematical modelling",
            "Only handwriting improvement",
            "Only counting objects",
            "Only naming shapes",
            QuestionOption.A,
            "Factorization is used in engineering, physics, computer science, and many areas where mathematical expressions need to be simplified.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Factorization",
            "Why is factorization useful when solving algebraic equations?",
            "It transforms complex expressions into simpler factors that are easier to analyze and solve.",
            "It removes variables from every equation.",
            "It prevents equations from being solved.",
            "It only changes the appearance of numbers.",
            QuestionOption.A,
            "Factorization helps identify possible solutions by rewriting expressions as products of simpler terms.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Introduction to Rational Expressions
        // ==========================================================

        AddQuestion(
            "Introduction to Rational Expressions",
            "What is a rational expression?",
            "An algebraic expression written as the quotient of two polynomials",
            "An equation containing only fractions",
            "An expression containing square roots only",
            "A polynomial with no variables",
            QuestionOption.A,
            "A rational expression is a fraction in which both the numerator and denominator are polynomials, and the denominator is not zero.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Rational Expressions",
            "Which of the following is a rational expression?",
            "(x + 2)/(x - 1)",
            "√x + 5",
            "x² + √x",
            "2ˣ + 1",
            QuestionOption.A,
            "A rational expression is formed by dividing one polynomial by another polynomial.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Rational Expressions",
            "Why must the denominator of a rational expression never be zero?",
            "Because the numerator would become zero.",
            "Because division by zero is undefined.",
            "Because the expression becomes a polynomial.",
            "Because the variables disappear.",
            QuestionOption.B,
            "Division by zero is undefined in mathematics, so any value that makes the denominator zero is excluded from the domain.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Rational Expressions",
            "What is meant by the domain of a rational expression?",
            "The degree of the numerator",
            "The values for which the expression is defined",
            "The number of variables in the expression",
            "The coefficient of the highest-degree term",
            QuestionOption.B,
            "The domain consists of all values that do not make the denominator equal to zero.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Rational Expressions",
            "How are rational expressions related to numerical fractions?",
            "They follow similar rules, but use polynomials instead of numbers.",
            "They are exactly the same as whole numbers.",
            "They can never be simplified.",
            "They always have a denominator of one.",
            QuestionOption.A,
            "Rational expressions extend the idea of fractions by replacing numbers with polynomials while following many of the same mathematical rules.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Simplifying and Operating on Rational Expressions
        // ==========================================================

        AddQuestion(
            "Simplifying and Operating on Rational Expressions",
            "What is the first step when simplifying a rational expression?",
            "Factor the numerator and denominator",
            "Add the numerator and denominator",
            "Remove all variables",
            "Multiply all terms randomly",
            QuestionOption.A,
            "To simplify rational expressions, factor the numerator and denominator first, then cancel common factors.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Simplifying and Operating on Rational Expressions",
            "Simplify: 6x / 3",
            "2x",
            "3x",
            "6x",
            "x/2",
            QuestionOption.A,
            "Divide the coefficient 6 by 3 to get 2, so 6x/3 = 2x.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Simplifying and Operating on Rational Expressions",
            "When adding rational expressions with different denominators, what must be found first?",
            "A common denominator",
            "A common numerator",
            "A square root",
            "A factor of zero",
            QuestionOption.A,
            "Fractions with different denominators must be converted to equivalent forms using a common denominator before adding.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Simplifying and Operating on Rational Expressions",
            "Simplify: x² / x",
            "x",
            "x²",
            "1/x",
            "2x",
            QuestionOption.A,
            "Cancel the common factor x from numerator and denominator, leaving x (where x ≠ 0).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Simplifying and Operating on Rational Expressions",
            "Why are operations on rational expressions important in algebra?",
            "They help simplify complex expressions and solve equations involving fractions and variables.",
            "They only work with whole numbers.",
            "They remove the need for algebraic rules.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Rational expressions are used in advanced algebra, calculus, physics, engineering, and many mathematical models.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Rational Expressions
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Rational Expressions",
            "A car travels a distance of d kilometers in t hours. Which rational expression represents its average speed?",
            "d + t",
            "d / t",
            "d × t",
            "t / d",
            QuestionOption.B,
            "Average speed is calculated using the formula distance divided by time, so speed = d/t.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Rational Expressions",
            "A worker completes a job in x hours. Which expression represents the work rate?",
            "x",
            "1/x",
            "x²",
            "x + 1",
            QuestionOption.B,
            "Rate is the amount of work divided by time. If one job is completed in x hours, the rate is 1/x.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Rational Expressions",
            "A formula contains the expression (x² - 9)/(x - 3). What is the simplified form?",
            "x - 3",
            "x + 3",
            "x² + 3",
            "1",
            QuestionOption.B,
            "Factor the numerator: x² - 9 = (x - 3)(x + 3). Cancel the common factor (x - 3), leaving x + 3 (where x ≠ 3).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Rational Expressions",
            "Which real-world situation can be represented using rational expressions?",
            "Calculating speed, rates, and proportions",
            "Only naming geometric shapes",
            "Only counting objects",
            "Only drawing graphs",
            QuestionOption.A,
            "Rational expressions are commonly used for rates, ratios, speed, and relationships involving division.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Rational Expressions",
            "Why are rational expressions important in advanced mathematics?",
            "They help model relationships involving rates, variables, and changing quantities.",
            "They are only used for simple arithmetic.",
            "They cannot represent real-world problems.",
            "They eliminate the need for equations.",
            QuestionOption.A,
            "Rational expressions are widely used in algebra, calculus, physics, engineering, and scientific modelling.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Exponents
        // ==========================================================

        AddQuestion(
            "Introduction to Exponents",
            "What does an exponent represent?",
            "Repeated addition of a number",
            "Repeated multiplication of a base by itself",
            "Division of two numbers",
            "The square root of a number",
            QuestionOption.B,
            "An exponent indicates how many times the base is multiplied by itself. For example, 2³ = 2 × 2 × 2.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Exponents",
            "In the expression 5⁴, which number is the base?",
            "4",
            "5",
            "20",
            "9",
            QuestionOption.B,
            "The base is the number being repeatedly multiplied. In 5⁴, the base is 5 and the exponent is 4.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Exponents",
            "What is the exponent in the expression x⁶?",
            "x",
            "6",
            "x⁶",
            "1",
            QuestionOption.B,
            "The exponent tells how many times the base is multiplied by itself. In x⁶, the exponent is 6.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Exponents",
            "Which expression represents 3 × 3 × 3 × 3?",
            "3²",
            "3³",
            "3⁴",
            "4³",
            QuestionOption.C,
            "The base 3 is multiplied by itself four times, so the expression is written as 3⁴.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Exponents",
            "Why are exponents widely used in mathematics and science?",
            "They make repeated multiplication easier to write and calculate.",
            "They can only represent square numbers.",
            "They replace variables in equations.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Exponents provide a compact way to represent repeated multiplication and are fundamental in algebra, physics, engineering, computer science, and finance.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Laws and Operations of Exponents
        // ==========================================================

        AddQuestion(
            "Laws and Operations of Exponents",
            "Which exponent law is used when multiplying powers with the same base?",
            "Add the exponents",
            "Subtract the exponents",
            "Multiply the bases only",
            "Divide the exponents",
            QuestionOption.A,
            "When multiplying powers with the same base, the exponents are added: aᵐ × aⁿ = aᵐ⁺ⁿ.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Laws and Operations of Exponents",
            "Simplify: x³ × x²",
            "x⁵",
            "x⁶",
            "x",
            "x²",
            QuestionOption.A,
            "Using the product rule of exponents, add the powers: x³ × x² = x³⁺² = x⁵.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Laws and Operations of Exponents",
            "What is the value of any non-zero number raised to the power of zero?",
            "The number itself",
            "Zero",
            "One",
            "Undefined",
            QuestionOption.C,
            "The zero exponent rule states that a⁰ = 1 for any non-zero value of a.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Laws and Operations of Exponents",
            "Simplify: (x²)³",
            "x⁵",
            "x⁶",
            "x⁹",
            "x²",
            QuestionOption.B,
            "Using the power of a power rule, multiply the exponents: (x²)³ = x²×³ = x⁶.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Laws and Operations of Exponents",
            "Why are exponent laws important in mathematics?",
            "They simplify calculations and help solve complex expressions efficiently.",
            "They remove variables from equations.",
            "They only apply to geometry.",
            "They are only used for counting numbers.",
            QuestionOption.A,
            "Exponent rules are essential for simplifying expressions in algebra, calculus, science, engineering, and computing.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Applications and Practice of Exponents
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Exponents",
            "Scientific notation is mainly used to represent which type of numbers?",
            "Very large or very small numbers",
            "Only whole numbers",
            "Only negative numbers",
            "Only fractions",
            QuestionOption.A,
            "Scientific notation uses powers of 10 to represent extremely large or small values in a compact form.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Exponents",
            "Express 1,000,000 using scientific notation.",
            "1 × 10⁶",
            "1 × 10³",
            "10 × 10⁶",
            "100 × 10²",
            QuestionOption.A,
            "1,000,000 has six zeros, so it can be written as 1 × 10⁶.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Exponents",
            "A population doubles every year. Which mathematical concept can represent this growth?",
            "Exponential growth",
            "Linear growth",
            "Constant value",
            "Factorization",
            QuestionOption.A,
            "When a quantity grows by a constant multiplier over time, it is represented using exponential growth.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Exponents",
            "Simplify: 2³ × 2⁴",
            "2⁷",
            "2¹²",
            "4⁷",
            "2¹",
            QuestionOption.A,
            "Using the exponent multiplication rule, add the powers: 2³ × 2⁴ = 2³⁺⁴ = 2⁷.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Exponents",
            "Why are exponent concepts important in science and technology?",
            "They help model growth, decay, measurements, and extremely large or small quantities.",
            "They are only used for simple addition.",
            "They cannot represent real-world situations.",
            "They are only useful in geometry.",
            QuestionOption.A,
            "Exponents are widely used in physics, computing, biology, finance, and scientific calculations.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Radicals and Surds
        // ==========================================================

        AddQuestion(
            "Introduction to Radicals and Surds",
            "What is a radical in mathematics?",
            "A symbol used to represent a root of a number or expression",
            "A symbol used for multiplication",
            "A type of polynomial",
            "An equation with two variables",
            QuestionOption.A,
            "A radical is represented by the symbol √ and is used to indicate roots such as square roots and cube roots.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Radicals and Surds",
            "Which of the following is a surd?",
            "√16",
            "√25",
            "√2",
            "√81",
            QuestionOption.C,
            "A surd is an irrational root that cannot be simplified into a rational number. √2 is a surd, while √16, √25, and √81 simplify to whole numbers.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Radicals and Surds",
            "What is the value of √49?",
            "6",
            "7",
            "8",
            "9",
            QuestionOption.B,
            "Since 7 × 7 = 49, the principal square root of 49 is 7.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Radicals and Surds",
            "Which statement correctly describes a surd?",
            "It can always be written as a whole number.",
            "It represents an irrational root that cannot be simplified exactly.",
            "It is always equal to zero.",
            "It is another name for a fraction.",
            QuestionOption.B,
            "Surds represent irrational roots that cannot be expressed exactly as fractions or terminating decimals.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Radicals and Surds",
            "Why are radicals and surds important in mathematics?",
            "They are only used in arithmetic.",
            "They help represent and solve problems involving irrational roots in algebra, geometry, and science.",
            "They replace all fractions.",
            "They are only useful for calculating percentages.",
            QuestionOption.B,
            "Radicals and surds are widely used in algebra, geometry, engineering, physics, and many scientific calculations involving irrational numbers.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Simplifying and Operating on Radicals
        // ==========================================================

        AddQuestion(
            "Simplifying and Operating on Radicals",
            "Simplify: √16",
            "2",
            "4",
            "8",
            "16",
            QuestionOption.B,
            "The square root of 16 is 4 because 4 × 4 = 16.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Simplifying and Operating on Radicals",
            "What is the first step when simplifying a radical expression?",
            "Find perfect square factors inside the radical",
            "Remove all variables",
            "Multiply all numbers together",
            "Convert it into a fraction",
            QuestionOption.A,
            "To simplify radicals, identify perfect square factors that can be taken outside the radical symbol.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Simplifying and Operating on Radicals",
            "Simplify: √50",
            "5√2",
            "2√5",
            "5√10",
            "10√5",
            QuestionOption.B,
            "√50 = √(25 × 2) = √25 × √2 = 5√2.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Simplifying and Operating on Radicals",
            "Which condition allows two radical terms to be added or subtracted directly?",
            "They must have the same radicand",
            "They must have different variables",
            "They must have different square roots",
            "They must always be integers",
            QuestionOption.A,
            "Only like radicals, which have the same radicand, can be combined by addition or subtraction.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Simplifying and Operating on Radicals",
            "Why is rationalizing the denominator used in radical expressions?",
            "To remove radicals from the denominator and make expressions simpler.",
            "To increase the number of radicals.",
            "To remove all variables.",
            "To convert every expression into a decimal.",
            QuestionOption.A,
            "Rationalizing the denominator creates an equivalent expression with a rational denominator, making calculations easier.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Radicals and Surds
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Radicals and Surds",
            "Which real-world field commonly uses radicals and surds?",
            "Geometry and engineering",
            "Only basic counting",
            "Only alphabetical sorting",
            "Only data storage",
            QuestionOption.A,
            "Radicals are used in geometry, physics, engineering, and measurement calculations involving distances and lengths.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Radicals and Surds",
            "The distance formula uses square roots. Why are radicals useful in this situation?",
            "They help calculate exact distances between points.",
            "They remove the need for measurements.",
            "They only work with whole numbers.",
            "They convert all values to zero.",
            QuestionOption.A,
            "Distance calculations often involve square roots, making radicals useful for finding exact lengths.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Radicals and Surds",
            "Simplify: √9 + √16",
            "5",
            "7",
            "25",
            "√25",
            QuestionOption.B,
            "√9 = 3 and √16 = 4, so √9 + √16 = 3 + 4 = 7.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Radicals and Surds",
            "A square has an area of 50 cm². Which expression represents the length of one side?",
            "√50 cm",
            "50² cm",
            "25 cm",
            "50 + 50 cm",
            QuestionOption.A,
            "The side length of a square is the square root of its area, so the side is √50 cm.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Radicals and Surds",
            "Why are radicals and surds important in advanced mathematics?",
            "They allow exact representation of values that cannot always be written as simple integers or fractions.",
            "They only work for basic arithmetic.",
            "They eliminate mathematical formulas.",
            "They are only used for drawing shapes.",
            QuestionOption.A,
            "Radicals appear throughout algebra, geometry, calculus, physics, and engineering when exact values are required.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Logarithms
        // ==========================================================

        AddQuestion(
            "Introduction to Logarithms",
            "What is a logarithm?",
            "A way of expressing repeated addition",
            "The exponent to which a base must be raised to produce a given number",
            "The square root of a number",
            "A type of polynomial",
            QuestionOption.B,
            "A logarithm answers the question: 'To what exponent must the base be raised to obtain a given value?'",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Logarithms",
            "Logarithms are the inverse operation of which mathematical concept?",
            "Addition",
            "Subtraction",
            "Multiplication",
            "Exponentiation",
            QuestionOption.D,
            "Logarithms reverse exponentiation. For example, if 2³ = 8, then log₂(8) = 3.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Logarithms",
            "In the expression log₁₀(100) = 2, what is the base?",
            "2",
            "10",
            "100",
            "1",
            QuestionOption.B,
            "The small number written below the logarithm symbol is the base. Here, the base is 10.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Logarithms",
            "What does log₂(8) = 3 mean?",
            "2 + 3 = 8",
            "2 × 3 = 8",
            "2³ = 8",
            "8³ = 2",
            QuestionOption.C,
            "The logarithm states that raising the base 2 to the exponent 3 produces 8.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Logarithms",
            "Why are logarithms important in mathematics and science?",
            "They are only used in geometry.",
            "They help solve exponential problems and model real-world phenomena such as population growth, earthquakes, and sound intensity.",
            "They replace fractions in algebra.",
            "They are only used for basic arithmetic.",
            QuestionOption.B,
            "Logarithms simplify calculations involving exponential relationships and are widely used in mathematics, engineering, physics, chemistry, finance, and computer science.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Laws and Properties of Logarithms
        // ==========================================================

        AddQuestion(
            "Laws and Properties of Logarithms",
            "Which logarithm property is used when multiplying two numbers inside a logarithm?",
            "Product rule",
            "Quotient rule",
            "Power rule",
            "Zero rule",
            QuestionOption.A,
            "The product rule states that log(ab) = log(a) + log(b), allowing multiplication to be converted into addition.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Laws and Properties of Logarithms",
            "Which property states that log(a/b) = log(a) - log(b)?",
            "Product rule",
            "Quotient rule",
            "Power rule",
            "Inverse rule",
            QuestionOption.B,
            "The quotient rule converts division inside a logarithm into subtraction of logarithms.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Laws and Properties of Logarithms",
            "Simplify using the power rule: log(x³)",
            "3log(x)",
            "log(x)³",
            "xlog(3)",
            "log(x + 3)",
            QuestionOption.A,
            "The power rule states that log(xⁿ) = n log(x), so log(x³) = 3log(x).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Laws and Properties of Logarithms",
            "What is the relationship between exponential and logarithmic forms?",
            "They are inverse operations.",
            "They are unrelated operations.",
            "They always produce the same value.",
            "They only work with negative numbers.",
            QuestionOption.A,
            "Logarithms undo exponentiation, making them inverse operations of exponential functions.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Laws and Properties of Logarithms",
            "Why are logarithm properties important in mathematics?",
            "They simplify complex expressions and help solve exponential equations.",
            "They remove all mathematical operations.",
            "They are only used for geometry.",
            "They only apply to whole numbers.",
            QuestionOption.A,
            "Logarithm laws are essential in algebra, calculus, computer science, finance, and scientific modelling.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Logarithms
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Logarithms",
            "Which real-world situation commonly uses logarithms?",
            "Measuring earthquake intensity and sound levels",
            "Counting simple objects",
            "Naming geometric shapes",
            "Drawing straight lines",
            QuestionOption.A,
            "Logarithms are used in scales such as the Richter scale for earthquakes, decibel scale for sound, and many scientific measurements.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Logarithms",
            "Why are logarithms useful for representing very large numbers?",
            "They compress large values into smaller, manageable scales.",
            "They remove all numbers completely.",
            "They only work with negative values.",
            "They convert numbers into fractions only.",
            QuestionOption.A,
            "Logarithmic scales make it easier to compare extremely large or small quantities.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Logarithms",
            "If log₁₀(1000) = x, what is the value of x?",
            "2",
            "3",
            "10",
            "1000",
            QuestionOption.B,
            "Since 10³ = 1000, log₁₀(1000) = 3.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Logarithms",
            "A scientist uses logarithms to analyze population growth. Why are logarithms helpful?",
            "They help study exponential relationships and growth patterns.",
            "They remove the need for calculations.",
            "They only represent linear changes.",
            "They cannot be used with variables.",
            QuestionOption.A,
            "Logarithms are useful when working with exponential growth, decay, and changing quantities over time.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Logarithms",
            "Why are logarithms important in advanced mathematics and technology?",
            "They are used in algorithms, data analysis, scientific modelling, and solving exponential problems.",
            "They are only used for basic arithmetic.",
            "They have no practical applications.",
            "They only apply to geometry.",
            QuestionOption.A,
            "Logarithms are widely used in computer science, engineering, physics, finance, and information theory.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Absolute Value
        // ==========================================================

        AddQuestion(
            "Introduction to Absolute Value",
            "What does the absolute value of a number represent?",
            "Its distance from zero on the number line",
            "Its opposite value",
            "Its square root",
            "Its largest factor",
            QuestionOption.A,
            "The absolute value of a number is its non-negative distance from zero, regardless of its direction.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Absolute Value",
            "What is the absolute value of -8?",
            "-8",
            "8",
            "0",
            "16",
            QuestionOption.B,
            "Absolute value measures distance from zero, so |-8| = 8.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Absolute Value",
            "Which notation is used to represent the absolute value of x?",
            "(x)",
            "[x]",
            "|x|",
            "{x}",
            QuestionOption.C,
            "Absolute value is represented using two vertical bars, such as |x|.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Absolute Value",
            "Which statement about absolute value is always true?",
            "It is always negative.",
            "It is always less than zero.",
            "It is always greater than or equal to zero.",
            "It is always equal to the original number.",
            QuestionOption.C,
            "Since absolute value represents distance from zero, it can never be negative.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Absolute Value",
            "Why is the concept of absolute value important in mathematics?",
            "It measures distance without considering direction and is widely used in algebra, geometry, and real-world applications.",
            "It is only used for solving fractions.",
            "It replaces exponents in equations.",
            "It is only applicable to positive numbers.",
            QuestionOption.A,
            "Absolute value is essential for measuring magnitude, solving equations and inequalities, and representing distances in mathematics, science, and engineering.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Operations and Equations with Absolute Value
        // ==========================================================

        AddQuestion(
            "Operations and Equations with Absolute Value",
            "What does the absolute value of a number represent?",
            "Its distance from zero on the number line",
            "Its opposite value",
            "Its decimal form",
            "Its square value",
            QuestionOption.A,
            "Absolute value represents the distance of a number from zero, so it is always non-negative.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Operations and Equations with Absolute Value",
            "Solve: |x| = 5",
            "x = 5 only",
            "x = -5 only",
            "x = ±5",
            "x = 0",
            QuestionOption.C,
            "Since both 5 and -5 are 5 units away from zero, |x| = 5 gives x = ±5.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Operations and Equations with Absolute Value",
            "Simplify: |-8| + |3|",
            "5",
            "11",
            "-5",
            "-11",
            QuestionOption.B,
            "The absolute values are |-8| = 8 and |3| = 3, so the sum is 8 + 3 = 11.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Operations and Equations with Absolute Value",
            "When solving an absolute value equation |x| = a where a is positive, how many solutions are usually possible?",
            "One solution",
            "Two solutions",
            "No solutions",
            "Infinite solutions",
            QuestionOption.B,
            "For a positive value of a, both x = a and x = -a satisfy the equation.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Operations and Equations with Absolute Value",
            "Why are absolute value equations useful in real-world problems?",
            "They help model situations involving distance, error, and differences without considering direction.",
            "They only work with negative numbers.",
            "They remove all variables from equations.",
            "They are only used for geometry.",
            QuestionOption.A,
            "Absolute value is widely used in measurements, statistics, computer science, and engineering to represent magnitude or distance.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Absolute Value
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Absolute Value",
            "A person walks 5 km east and another person walks 5 km west from the same point. How can absolute value describe their distances?",
            "Both distances are represented as 5 km because direction is ignored.",
            "The west distance becomes negative.",
            "The east distance becomes zero.",
            "Absolute value cannot represent distance.",
            QuestionOption.A,
            "Absolute value represents distance from a reference point without considering direction.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Absolute Value",
            "A temperature changes from 20°C to 15°C. What is the absolute change in temperature?",
            "5°C",
            "-5°C",
            "35°C",
            "0°C",
            QuestionOption.A,
            "The difference is 15 - 20 = -5, and the absolute value gives |-5| = 5°C.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Absolute Value",
            "A machine has an error of ±0.02 cm in measurement. Why is absolute value useful here?",
            "It represents the size of the error regardless of whether it is positive or negative.",
            "It removes the measurement completely.",
            "It makes all values negative.",
            "It only works with whole numbers.",
            QuestionOption.A,
            "Absolute value is used to represent magnitude of error without considering the direction of deviation.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Absolute Value",
            "Solve: |2x| = 10",
            "x = ±5",
            "x = ±10",
            "x = 5 only",
            "x = 10 only",
            QuestionOption.A,
            "Since |2x| = 10, divide both sides by 2 to get |x| = 5, so x = ±5.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Absolute Value",
            "Why is absolute value important in advanced mathematics and technology?",
            "It helps model distance, optimization, errors, and differences between values.",
            "It only applies to simple arithmetic.",
            "It removes the need for mathematical models.",
            "It is only used for geometry.",
            QuestionOption.A,
            "Absolute value is widely used in statistics, computer science, engineering, optimization, and data analysis.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Algebraic Identities
        // ==========================================================

        AddQuestion(
            "Introduction to Algebraic Identities",
            "What is an algebraic identity?",
            "An equation that is true only for one specific value",
            "An equation that is true for all valid values of the variables",
            "An expression containing only constants",
            "An equation with two unknown variables",
            QuestionOption.B,
            "An algebraic identity is an equation that holds true for every valid value of its variables.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Algebraic Identities",
            "Which of the following is an algebraic identity?",
            "(a + b)² = a² + 2ab + b²",
            "x + 5 = 10",
            "2x = 8",
            "x² = 9",
            QuestionOption.A,
            "The expansion (a + b)² = a² + 2ab + b² is true for all values of a and b, making it an algebraic identity.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Algebraic Identities",
            "What is the main purpose of algebraic identities?",
            "To simplify expressions and solve mathematical problems efficiently",
            "To replace variables with constants",
            "To find the square root of numbers",
            "To compare two inequalities",
            QuestionOption.A,
            "Algebraic identities are widely used to simplify expressions, expand products, factorize expressions, and solve equations.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Algebraic Identities",
            "Which of the following is a commonly used algebraic identity?",
            "(a - b)² = a² - 2ab + b²",
            "a + b = ab",
            "a² + b² = (a + b)²",
            "a - b = 0",
            QuestionOption.A,
            "The identity (a - b)² = a² - 2ab + b² is one of the fundamental algebraic identities.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Algebraic Identities",
            "Why are algebraic identities important in mathematics?",
            "They provide universally true relationships that simplify calculations and are widely used in algebra, calculus, engineering, and science.",
            "They are only useful in arithmetic.",
            "They eliminate the need for variables.",
            "They are only used for graphing equations.",
            QuestionOption.A,
            "Algebraic identities form the foundation for simplifying expressions, solving equations, factorization, and advanced mathematical problem-solving across many disciplines.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applying Algebraic Identities
        // ==========================================================

        AddQuestion(
            "Applying Algebraic Identities",
            "Which identity is used to expand (a + b)²?",
            "a² + 2ab + b²",
            "a² - b²",
            "a² + b²",
            "a² - 2ab + b²",
            QuestionOption.A,
            "The square of a sum identity is (a + b)² = a² + 2ab + b².",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applying Algebraic Identities",
            "Expand: (x + 3)²",
            "x² + 6x + 9",
            "x² + 9",
            "x² + 3x + 9",
            "x² - 6x + 9",
            QuestionOption.A,
            "Using (a + b)² = a² + 2ab + b², we get x² + 2(x)(3) + 3² = x² + 6x + 9.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applying Algebraic Identities",
            "Which identity is used to simplify a² - b²?",
            "(a - b)(a + b)",
            "(a + b)²",
            "(a - b)²",
            "a² + b²",
            QuestionOption.A,
            "The difference of squares identity states that a² - b² = (a - b)(a + b).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applying Algebraic Identities",
            "Simplify: (x + y)(x - y)",
            "x² - y²",
            "x² + y²",
            "x² + 2xy + y²",
            "x² - 2xy + y²",
            QuestionOption.A,
            "Using the difference of squares identity, (x + y)(x - y) = x² - y².",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applying Algebraic Identities",
            "Why are algebraic identities useful?",
            "They provide shortcuts for expanding, simplifying, and factoring expressions.",
            "They remove all variables from equations.",
            "They only work with numbers.",
            "They replace all algebraic operations.",
            QuestionOption.A,
            "Algebraic identities make complex calculations faster and are widely used in algebra, calculus, and applied mathematics.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Algebraic Identities
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Algebraic Identities",
            "A square garden has side length (x + 5). Which algebraic identity can be used to find its area?",
            "(a + b)² = a² + 2ab + b²",
            "a² - b² = (a - b)(a + b)",
            "a³ + b³",
            "a² + b² = c²",
            QuestionOption.A,
            "The area of a square is side², so (x + 5)² can be expanded using the square of a sum identity.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Algebraic Identities",
            "Simplify: (2x + 3)²",
            "4x² + 12x + 9",
            "4x² + 9",
            "2x² + 6x + 3",
            "4x² - 12x + 9",
            QuestionOption.A,
            "Using (a + b)² = a² + 2ab + b², we get (2x)² + 2(2x)(3) + 3² = 4x² + 12x + 9.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Algebraic Identities",
            "An engineer uses algebraic identities to simplify design calculations. Why are identities useful?",
            "They reduce complex expressions and make calculations faster.",
            "They remove all variables from formulas.",
            "They only work with numbers.",
            "They prevent equations from being solved.",
            QuestionOption.A,
            "Algebraic identities provide standard patterns that simplify calculations in engineering and science.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Algebraic Identities",
            "Factorize: x² - 25",
            "(x - 5)(x + 5)",
            "(x - 25)(x + 25)",
            "(x - 5)²",
            "(x + 5)²",
            QuestionOption.A,
            "Using the difference of squares identity, x² - 25 = x² - 5² = (x - 5)(x + 5).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Algebraic Identities",
            "Why are algebraic identities important in higher mathematics?",
            "They help simplify expressions, prove relationships, and solve complex problems efficiently.",
            "They only apply to basic arithmetic.",
            "They replace all mathematical concepts.",
            "They cannot be used in real-world applications.",
            QuestionOption.A,
            "Algebraic identities are fundamental in algebra, calculus, physics, engineering, and computer science.",
            DifficultyLevel.Advance,
            5);


        // Geometry PQ. 2
        // ==========================================================
        // Introduction to Points, Lines & Angles
        // ==========================================================

        AddQuestion(
            "Introduction to Points, Lines & Angles",
            "What is a point in geometry?",
            "A figure with length and width",
            "An exact location with no size or dimensions",
            "A straight path extending infinitely",
            "A closed geometric shape",
            QuestionOption.B,
            "A point represents an exact location in space and has no length, width, or thickness.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Points, Lines & Angles",
            "Which geometric figure extends infinitely in both directions?",
            "Line Segment",
            "Ray",
            "Line",
            "Point",
            QuestionOption.C,
            "A line has no endpoints and extends infinitely in both directions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Points, Lines & Angles",
            "What is the main difference between a ray and a line segment?",
            "A ray has two endpoints.",
            "A line segment extends infinitely.",
            "A ray has one endpoint and extends infinitely in one direction.",
            "A line segment has no endpoints.",
            QuestionOption.C,
            "A ray begins at one endpoint and continues infinitely in one direction, whereas a line segment has two endpoints.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Points, Lines & Angles",
            "Which instrument is commonly used to measure angles?",
            "Compass",
            "Ruler",
            "Protractor",
            "Divider",
            QuestionOption.C,
            "A protractor is used to measure the size of angles in degrees.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Points, Lines & Angles",
            "Why are points, lines, and angles considered the foundation of geometry?",
            "Because they are only used to draw circles.",
            "Because every geometric figure is built from these basic elements.",
            "Because they only exist in coordinate geometry.",
            "Because they replace algebraic equations.",
            QuestionOption.B,
            "Points, lines, and angles are the fundamental building blocks from which all geometric shapes and structures are formed.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Types of Points, Lines & Angles
        // ==========================================================

        AddQuestion(
            "Types of Points, Lines & Angles",
            "Which type of geometric figure has a location but no size?",
            "Point",
            "Line",
            "Angle",
            "Plane",
            QuestionOption.A,
            "A point represents an exact location in geometry and has no length, width, or thickness.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Types of Points, Lines & Angles",
            "What is a line that extends infinitely in both directions called?",
            "Line segment",
            "Ray",
            "Line",
            "Angle",
            QuestionOption.C,
            "A line extends forever in both directions, while a ray has one endpoint and a line segment has two endpoints.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Types of Points, Lines & Angles",
            "What type of angle measures exactly 90 degrees?",
            "Acute angle",
            "Right angle",
            "Obtuse angle",
            "Straight angle",
            QuestionOption.B,
            "A right angle has a measure of exactly 90°, commonly seen at corners and perpendicular intersections.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Types of Points, Lines & Angles",
            "Two angles that add up to 180° are called what?",
            "Complementary angles",
            "Supplementary angles",
            "Vertical angles",
            "Adjacent angles",
            QuestionOption.B,
            "Supplementary angles have a combined measure of 180°.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Types of Points, Lines & Angles",
            "Why are different types of lines and angles important in geometry?",
            "They help describe shapes, structures, measurements, and relationships between geometric figures.",
            "They are only used for counting numbers.",
            "They cannot describe real objects.",
            "They only apply to algebra.",
            QuestionOption.A,
            "Lines and angles are fundamental concepts used in architecture, engineering, design, navigation, and mathematics.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Points, Lines & Angles
        // ==========================================================

        AddQuestion(
            "Applications of Points, Lines & Angles",
            "An architect uses lines and angles when designing buildings. Why are angles important in architecture?",
            "They help create accurate structures and maintain proper measurements.",
            "They remove the need for planning.",
            "They only decorate buildings.",
            "They cannot affect construction.",
            QuestionOption.A,
            "Angles are essential in architecture for designing stable structures, slopes, connections, and accurate layouts.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Points, Lines & Angles",
            "A navigation system uses angles to determine direction. Which concept is being applied?",
            "Angle measurement",
            "Polynomial factorization",
            "Number comparison",
            "Algebraic expansion",
            QuestionOption.A,
            "Angles are used in navigation systems to calculate directions, bearings, and positions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Points, Lines & Angles",
            "Engineers use perpendicular lines when designing structures. What does perpendicular mean?",
            "Two lines intersect to form a 90° angle.",
            "Two lines never meet.",
            "Two lines have the same length.",
            "Two lines are always curved.",
            QuestionOption.A,
            "Perpendicular lines meet at a right angle of 90°, which is important for stability and accurate construction.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Points, Lines & Angles",
            "Computer graphics use points, lines, and angles to create images. Why are these concepts useful?",
            "They help define shapes, positions, and movements in digital environments.",
            "They only work with physical objects.",
            "They cannot represent digital objects.",
            "They replace computer programming.",
            QuestionOption.A,
            "Geometry concepts are used in computer graphics, animation, games, and simulations to represent objects and movement.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Points, Lines & Angles",
            "Why are points, lines, and angles considered fundamental concepts in mathematics?",
            "They form the foundation for geometry, measurement, design, engineering, and spatial reasoning.",
            "They are only used for basic drawings.",
            "They have no real-world applications.",
            "They are unrelated to other mathematical topics.",
            QuestionOption.A,
            "Points, lines, and angles are core building blocks used throughout geometry and many applied sciences.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Introduction to Triangles
        // ==========================================================

        AddQuestion(
            "Introduction to Triangles",
            "What is a triangle?",
            "A polygon with four sides",
            "A polygon with three sides",
            "A shape with one curved side",
            "A polygon with five sides",
            QuestionOption.B,
            "A triangle is a polygon that has exactly three sides and three angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Triangles",
            "How many interior angles does a triangle have?",
            "2",
            "3",
            "4",
            "5",
            QuestionOption.B,
            "Every triangle has three interior angles formed by its three sides.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Triangles",
            "What is the sum of the interior angles of any triangle?",
            "90°",
            "180°",
            "270°",
            "360°",
            QuestionOption.B,
            "The sum of the three interior angles of every triangle is always 180°.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Triangles",
            "Which of the following is NOT a type of triangle based on its sides?",
            "Equilateral",
            "Isosceles",
            "Scalene",
            "Rectangle",
            QuestionOption.D,
            "A rectangle is a quadrilateral, not a type of triangle.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Triangles",
            "Why are triangles widely used in engineering and construction?",
            "They always have equal sides.",
            "They are the only shapes with three angles.",
            "They provide strength and structural stability.",
            "They can only be drawn with a compass.",
            QuestionOption.C,
            "Triangles are rigid shapes that distribute forces efficiently, making them ideal for bridges, roofs, towers, and other structures.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Types of Triangles
        // ==========================================================

        AddQuestion(
            "Types of Triangles",
            "A triangle with all three sides equal is called what?",
            "Scalene triangle",
            "Isosceles triangle",
            "Equilateral triangle",
            "Right triangle",
            QuestionOption.C,
            "An equilateral triangle has three equal sides and three equal angles of 60° each.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Types of Triangles",
            "A triangle with exactly two equal sides is called what?",
            "Equilateral triangle",
            "Isosceles triangle",
            "Scalene triangle",
            "Obtuse triangle",
            QuestionOption.B,
            "An isosceles triangle has at least two equal sides and two equal opposite angles.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Types of Triangles",
            "Which type of triangle has three different side lengths?",
            "Equilateral triangle",
            "Isosceles triangle",
            "Scalene triangle",
            "Right triangle",
            QuestionOption.C,
            "A scalene triangle has all three sides with different lengths and usually different angles.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Types of Triangles",
            "A triangle with one angle greater than 90° is called what?",
            "Acute triangle",
            "Right triangle",
            "Obtuse triangle",
            "Equilateral triangle",
            QuestionOption.C,
            "An obtuse triangle contains one angle that measures more than 90°.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Types of Triangles",
            "Why is classifying triangles important in geometry?",
            "It helps identify properties, solve problems, and understand relationships between shapes.",
            "It only changes the appearance of triangles.",
            "It removes the need for measurements.",
            "It is only useful for drawing pictures.",
            QuestionOption.A,
            "Triangle classification helps in geometry proofs, calculations, engineering, architecture, and design.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications of Triangles
        // ==========================================================

        AddQuestion(
            "Applications of Triangles",
            "Why are triangles commonly used in building structures and bridges?",
            "They provide strength and stability because of their rigid shape.",
            "They are the easiest shapes to draw.",
            "They cannot change size.",
            "They require no measurements.",
            QuestionOption.A,
            "Triangles are structurally stable because their shape does not easily deform under force.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Triangles",
            "Surveyors use triangles to measure distances and locations. Which concept is applied?",
            "Triangulation",
            "Factorization",
            "Polynomial division",
            "Logarithmic scaling",
            QuestionOption.A,
            "Triangulation uses triangle relationships to calculate unknown distances and positions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Triangles",
            "Which triangle property is useful in calculating unknown sides in engineering?",
            "Side-angle relationships",
            "Only the number of vertices",
            "Color of the triangle",
            "Position on a page",
            QuestionOption.A,
            "Properties such as the Pythagorean theorem and trigonometric relationships help calculate unknown measurements.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Triangles",
            "Computer graphics use triangles to create 3D models. Why are triangles useful?",
            "They can approximate complex surfaces and are easy to process computationally.",
            "They cannot represent shapes.",
            "They only work in two dimensions.",
            "They replace all computer algorithms.",
            QuestionOption.A,
            "3D graphics engines use triangular meshes because triangles are simple, stable, and efficient to calculate.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Triangles",
            "Why are triangles important in advanced mathematics and science?",
            "They are used in geometry, physics, engineering, navigation, and mathematical modelling.",
            "They are only used for basic drawings.",
            "They have no practical applications.",
            "They only apply to classroom exercises.",
            QuestionOption.A,
            "Triangles are fundamental in many fields including architecture, robotics, physics, and computer graphics.",
            DifficultyLevel.Advance,
            5);








        // ==========================================================
        // Introduction to Congruence
        // ==========================================================

        AddQuestion(
            "Introduction to Congruence",
            "What does it mean for two geometric figures to be congruent?",
            "They have the same shape only.",
            "They have the same size only.",
            "They have the same shape and the same size.",
            "They have the same area only.",
            QuestionOption.C,
            "Congruent figures have exactly the same shape and size, even if they are positioned differently.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Congruence",
            "Which symbol is commonly used to represent congruence?",
            "=",
            "≈",
            "∼",
            "≅",
            QuestionOption.D,
            "The symbol '≅' is used to indicate that two geometric figures are congruent.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Congruence",
            "If two triangles are congruent, which statement is always true?",
            "Only their areas are equal.",
            "Their corresponding sides and angles are equal.",
            "Only their perimeters are equal.",
            "They must be equilateral triangles.",
            QuestionOption.B,
            "Congruent triangles have all corresponding sides and corresponding angles equal.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Congruence",
            "Which of the following is NOT sufficient by itself to prove two figures are congruent?",
            "They have the same shape.",
            "Their corresponding sides and angles are equal.",
            "One can be placed exactly over the other.",
            "They have identical dimensions.",
            QuestionOption.A,
            "Having the same shape alone indicates similarity, not congruence, because the sizes may differ.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Congruence",
            "Why is congruence important in engineering and construction?",
            "It ensures components fit together accurately.",
            "It eliminates the need for measurements.",
            "It guarantees every structure is symmetrical.",
            "It is only used in classroom geometry.",
            QuestionOption.A,
            "Congruence ensures manufactured parts and structural components have identical dimensions so they fit and function correctly.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Congruence Criteria
        // ==========================================================

        AddQuestion(
            "Congruence Criteria",
            "Which congruence criterion states that three corresponding sides of two triangles are equal?",
            "SAS",
            "ASA",
            "SSS",
            "RHS",
            QuestionOption.C,
            "SSS (Side-Side-Side) congruence states that two triangles are congruent if all three corresponding sides are equal.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Congruence Criteria",
            "What does SAS stand for in triangle congruence?",
            "Side-Angle-Side",
            "Side-Area-Side",
            "Sum-Angle-Sum",
            "Side-Angle-Sum",
            QuestionOption.A,
            "SAS means Side-Angle-Side, where two sides and the included angle of one triangle match another triangle.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Congruence Criteria",
            "Which criterion proves two right-angled triangles are congruent when the hypotenuse and one side are equal?",
            "ASA",
            "RHS",
            "SSS",
            "AAA",
            QuestionOption.B,
            "RHS (Right angle-Hypotenuse-Side) criterion is used specifically for right-angled triangles.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Congruence Criteria",
            "Why can AAA not be used as a triangle congruence criterion?",
            "It proves similarity but not equal size.",
            "It only works for squares.",
            "It cannot compare angles.",
            "It proves all triangles are equal.",
            QuestionOption.A,
            "AAA only guarantees that triangles have the same shape, meaning they are similar, but their sizes may differ.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Congruence Criteria",
            "Why are congruence criteria important in geometry?",
            "They provide methods to prove that two shapes have the same size and shape.",
            "They only help draw triangles.",
            "They remove the need for measurements.",
            "They are only used for calculations.",
            QuestionOption.A,
            "Congruence criteria are essential for geometric proofs, construction, engineering, and design.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Congruence
        // ==========================================================

        AddQuestion(
            "Applications of Congruence",
            "Why is congruence important in manufacturing?",
            "It ensures identical parts are produced with the same size and shape.",
            "It removes the need for measurements.",
            "It only applies to drawings.",
            "It prevents objects from being copied.",
            QuestionOption.A,
            "Manufacturing uses congruence to create identical components that fit together accurately.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Congruence",
            "An engineer creates two identical bridge supports. Which geometric concept ensures they match?",
            "Congruence",
            "Similarity only",
            "Perimeter only",
            "Area only",
            QuestionOption.A,
            "Congruent figures have exactly the same shape and size, making them suitable for identical structures.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Congruence",
            "In surveying, why are congruent triangles useful?",
            "They help determine unknown distances and verify measurements accurately.",
            "They eliminate all calculations.",
            "They only measure angles.",
            "They cannot represent real locations.",
            QuestionOption.A,
            "Surveyors use congruent triangles to compare measurements and establish accurate positions.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Congruence",
            "Which situation is an example of congruence in everyday life?",
            "Two identical tiles placed in different locations.",
            "Two shapes with the same color but different sizes.",
            "Two objects with different shapes.",
            "A circle and a triangle of the same area.",
            QuestionOption.A,
            "Objects that have the same shape and size are congruent, even if their positions are different.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Congruence",
            "Why are congruence principles important in advanced mathematics and engineering?",
            "They help prove geometric relationships and create accurate designs and models.",
            "They only apply to simple drawings.",
            "They cannot be used in technology.",
            "They replace all mathematical calculations.",
            QuestionOption.A,
            "Congruence is used in geometry proofs, CAD design, engineering, architecture, and scientific modelling.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Introduction to Similarity
        // ==========================================================

        AddQuestion(
            "Introduction to Similarity",
            "What does it mean for two geometric figures to be similar?",
            "They have the same size only.",
            "They have the same shape but may have different sizes.",
            "They have the same perimeter only.",
            "They have equal angles only.",
            QuestionOption.B,
            "Similar figures have the same shape, while their corresponding sides are proportional and their sizes may differ.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Similarity",
            "Which of the following is always true for similar figures?",
            "Their corresponding angles are equal.",
            "Their corresponding sides are equal.",
            "Their areas are equal.",
            "Their perimeters are always equal.",
            QuestionOption.A,
            "In similar figures, corresponding angles are equal, while corresponding sides are proportional.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Similarity",
            "What is the relationship between the corresponding sides of similar figures?",
            "They are always equal.",
            "They are always perpendicular.",
            "They are proportional.",
            "They have no relationship.",
            QuestionOption.C,
            "The lengths of corresponding sides in similar figures have the same ratio, known as the scale factor.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Similarity",
            "Which statement correctly distinguishes similarity from congruence?",
            "Similar figures must have the same size.",
            "Congruent figures may have different sizes.",
            "Similar figures have the same shape, while congruent figures have the same shape and size.",
            "Similarity and congruence mean the same thing.",
            QuestionOption.C,
            "Congruence requires identical shape and size, whereas similarity requires only the same shape with proportional dimensions.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Similarity",
            "Why is the concept of similarity important in real-world applications?",
            "It is only useful for drawing geometric figures.",
            "It helps create scaled models, maps, blueprints, and architectural designs.",
            "It replaces the need for measurements.",
            "It is only used in triangle problems.",
            QuestionOption.B,
            "Similarity is widely used to create accurate scale models, maps, engineering drawings, and architectural plans.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Similarity Criteria
        // ==========================================================

        AddQuestion(
            "Similarity Criteria",
            "Which similarity criterion states that two triangles are similar if their corresponding angles are equal?",
            "AA",
            "SSS",
            "SAS",
            "RHS",
            QuestionOption.A,
            "AA (Angle-Angle) similarity states that if two corresponding angles of triangles are equal, the triangles are similar.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Similarity Criteria",
            "What does SAS similarity compare between two triangles?",
            "Two sides and the included angle",
            "Three equal sides only",
            "Three equal angles only",
            "Only the areas",
            QuestionOption.A,
            "SAS similarity proves triangles are similar when two pairs of corresponding sides are proportional and the included angles are equal.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Similarity Criteria",
            "Which similarity criterion uses all three pairs of corresponding sides being proportional?",
            "AA",
            "SSS",
            "SAS",
            "ASA",
            QuestionOption.B,
            "SSS similarity states that if all corresponding sides are in the same ratio, the triangles are similar.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Similarity Criteria",
            "What is the main difference between congruent and similar triangles?",
            "Congruent triangles have the same size and shape, while similar triangles have the same shape but may have different sizes.",
            "Similar triangles always have different shapes.",
            "Congruent triangles have different angles.",
            "Similarity only applies to circles.",
            QuestionOption.A,
            "Similarity preserves shape while allowing size changes through proportional scaling.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Similarity Criteria",
            "Why are similarity criteria important in geometry?",
            "They help solve problems involving scale, measurements, proportions, and indirect calculations.",
            "They only help draw triangles.",
            "They remove the need for ratios.",
            "They cannot be used in real-world applications.",
            QuestionOption.A,
            "Similarity is widely used in architecture, maps, engineering, photography, and measurement problems.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Similarity
        // ==========================================================

        AddQuestion(
            "Applications of Similarity",
            "Why is similarity useful in map making?",
            "It allows large areas to be represented accurately at smaller scales.",
            "It removes the need for measurements.",
            "It changes the shape of locations.",
            "It only works with circles.",
            QuestionOption.A,
            "Maps use similar figures because they maintain the same shape while reducing or enlarging size using a scale factor.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Similarity",
            "Architects create small models of buildings before construction. Which concept is being applied?",
            "Similarity",
            "Factorization",
            "Congruence only",
            "Probability",
            QuestionOption.A,
            "Architectural models are scaled versions of real buildings that preserve the same shape through similarity.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Similarity",
            "Surveyors use similar triangles to calculate distances that are difficult to measure directly. Why does this work?",
            "Corresponding sides maintain proportional relationships.",
            "All triangles have equal sizes.",
            "Angles do not matter in triangles.",
            "Similarity removes measurements completely.",
            QuestionOption.A,
            "Similar triangles allow unknown distances to be calculated using ratios between corresponding sides.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Similarity",
            "A photograph is enlarged while keeping the same shape. Which geometric concept describes this?",
            "Similarity",
            "Congruence",
            "Reflection",
            "Rotation",
            QuestionOption.A,
            "Scaling an image changes its size while preserving its shape, which is a property of similar figures.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Similarity",
            "Why are similarity principles important in engineering and computer graphics?",
            "They allow accurate scaling, modelling, and representation of objects while preserving shape.",
            "They only apply to classroom exercises.",
            "They prevent objects from being resized.",
            "They are unrelated to technology.",
            QuestionOption.A,
            "Similarity is used in CAD design, 3D modelling, simulations, engineering prototypes, and digital graphics.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Introduction to Quadrilaterals
        // ==========================================================

        AddQuestion(
            "Introduction to Quadrilaterals",
            "What is a quadrilateral?",
            "A polygon with three sides",
            "A polygon with four sides",
            "A polygon with five sides",
            "A shape with one curved side",
            QuestionOption.B,
            "A quadrilateral is a closed polygon that has exactly four sides and four angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Quadrilaterals",
            "How many interior angles does every quadrilateral have?",
            "Three",
            "Four",
            "Five",
            "Six",
            QuestionOption.B,
            "Every quadrilateral has four interior angles because it has four sides.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Quadrilaterals",
            "What is the sum of the interior angles of any quadrilateral?",
            "180°",
            "270°",
            "360°",
            "540°",
            QuestionOption.C,
            "The sum of the interior angles of every quadrilateral is always 360°.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Quadrilaterals",
            "Which of the following is NOT a type of quadrilateral?",
            "Rectangle",
            "Rhombus",
            "Pentagon",
            "Trapezium",
            QuestionOption.C,
            "A pentagon has five sides, whereas a quadrilateral has exactly four sides.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Quadrilaterals",
            "Why are quadrilaterals widely used in architecture and engineering?",
            "They can only be drawn using a compass.",
            "They form the basis of many stable structures, floor plans, windows, and mechanical designs.",
            "They always have four equal sides.",
            "They are only used in mathematics textbooks.",
            QuestionOption.B,
            "Quadrilaterals such as rectangles and squares are commonly used in construction, engineering, manufacturing, and design because of their practical shapes and properties.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Types of Quadrilaterals
        // ==========================================================

        AddQuestion(
            "Types of Quadrilaterals",
            "A quadrilateral with four equal sides and four right angles is called what?",
            "Rectangle",
            "Square",
            "Trapezium",
            "Kite",
            QuestionOption.B,
            "A square has four equal sides and four right angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Types of Quadrilaterals",
            "Which quadrilateral has both pairs of opposite sides parallel?",
            "Parallelogram",
            "Kite",
            "Trapezium",
            "Pentagon",
            QuestionOption.A,
            "A parallelogram is a quadrilateral with two pairs of opposite sides that are parallel.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Types of Quadrilaterals",
            "Which property is unique to a rectangle?",
            "All sides are always equal.",
            "All angles are 90 degrees.",
            "Only one pair of sides is parallel.",
            "No sides are equal.",
            QuestionOption.B,
            "A rectangle has four right angles, although only opposite sides are equal in length.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Types of Quadrilaterals",
            "A rhombus is a quadrilateral where:",
            "All four sides are equal.",
            "All angles are different.",
            "Only two sides are equal.",
            "No sides are parallel.",
            QuestionOption.A,
            "A rhombus has four equal sides, while its angles do not necessarily have to be right angles.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Types of Quadrilaterals",
            "Why is classifying quadrilaterals important in geometry?",
            "It helps identify properties, solve problems, and understand relationships between shapes.",
            "It only changes the names of shapes.",
            "It removes the need for measurements.",
            "It only applies to drawings.",
            QuestionOption.A,
            "Understanding quadrilateral properties is important in geometry proofs, architecture, engineering, and design.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Quadrilaterals
        // ==========================================================

        AddQuestion(
            "Applications of Quadrilaterals",
            "Why are rectangles commonly used in architecture and construction?",
            "They provide practical shapes for rooms, buildings, and structures.",
            "They cannot be measured accurately.",
            "They only exist in drawings.",
            "They have no real-world applications.",
            QuestionOption.A,
            "Rectangles are widely used in construction because they provide efficient layouts and easy measurement.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Quadrilaterals",
            "A floor tile has four equal sides and four right angles. Which quadrilateral shape is it?",
            "Square",
            "Trapezium",
            "Kite",
            "Parallelogram",
            QuestionOption.A,
            "A square has four equal sides and four right angles, making it common in tiles and designs.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Quadrilaterals",
            "Engineers use parallelograms in designs because:",
            "They help model forces, structures, and balanced shapes.",
            "They cannot represent measurements.",
            "They only work for circular objects.",
            "They have no mathematical properties.",
            QuestionOption.A,
            "Parallelograms are useful in engineering because of their parallel sides and predictable geometric properties.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Quadrilaterals",
            "Computer graphics use quadrilateral shapes in modelling. Why are they useful?",
            "They help create surfaces and represent objects efficiently.",
            "They cannot be displayed digitally.",
            "They only represent numbers.",
            "They prevent objects from being scaled.",
            QuestionOption.A,
            "Quadrilaterals are commonly used in graphics, CAD, and 3D modelling to represent surfaces and designs.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Quadrilaterals",
            "Why are quadrilateral properties important in advanced fields?",
            "They support accurate design, construction, engineering analysis, and mathematical modelling.",
            "They are only useful for naming shapes.",
            "They cannot be applied outside classrooms.",
            "They replace all other geometric concepts.",
            QuestionOption.A,
            "Quadrilaterals are fundamental in architecture, engineering, computer graphics, and structural design.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Polygons
        // ==========================================================

        AddQuestion(
            "Introduction to Polygons",
            "What is a polygon?",
            "A closed figure made of curved lines",
            "A closed plane figure formed by straight line segments",
            "A three-dimensional shape",
            "A figure with only one side",
            QuestionOption.B,
            "A polygon is a closed two-dimensional figure made up entirely of straight line segments.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Polygons",
            "Which of the following is NOT a polygon?",
            "Triangle",
            "Rectangle",
            "Circle",
            "Pentagon",
            QuestionOption.C,
            "A circle has a curved boundary, while polygons are made only of straight sides.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Polygons",
            "How are polygons commonly classified?",
            "By their colour",
            "By the number of their sides",
            "By their area only",
            "By their perimeter only",
            QuestionOption.B,
            "Polygons are primarily classified according to the number of sides they have, such as triangles, quadrilaterals, pentagons, and hexagons.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Polygons",
            "Which statement about a regular polygon is correct?",
            "Only its sides are equal.",
            "Only its angles are equal.",
            "All its sides and all its interior angles are equal.",
            "It must have exactly six sides.",
            QuestionOption.C,
            "A regular polygon has all sides of equal length and all interior angles equal.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Polygons",
            "Why are polygons important in engineering, architecture, and computer graphics?",
            "They are only used for classroom exercises.",
            "They provide the foundation for designing structures, models, and digital objects.",
            "They can only represent two-dimensional drawings.",
            "They eliminate the need for measurements.",
            QuestionOption.B,
            "Polygons are fundamental in construction, CAD software, computer graphics, and engineering because complex shapes are often built from polygonal components.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Types of Polygons
        // ==========================================================

        AddQuestion(
            "Types of Polygons",
            "A polygon with three sides is called what?",
            "Quadrilateral",
            "Triangle",
            "Pentagon",
            "Hexagon",
            QuestionOption.B,
            "A triangle is a polygon with three sides and three angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Types of Polygons",
            "A polygon with all sides and angles equal is called what?",
            "Irregular polygon",
            "Concave polygon",
            "Regular polygon",
            "Open polygon",
            QuestionOption.C,
            "A regular polygon has equal side lengths and equal interior angles.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Types of Polygons",
            "How many sides does a hexagon have?",
            "Five",
            "Six",
            "Seven",
            "Eight",
            QuestionOption.B,
            "A hexagon is a polygon with six sides and six angles.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Types of Polygons",
            "What is the difference between a convex and concave polygon?",
            "A convex polygon has no inward angles, while a concave polygon has at least one inward angle.",
            "A convex polygon has curved sides.",
            "A concave polygon always has equal sides.",
            "They are exactly the same.",
            QuestionOption.A,
            "Convex polygons have all interior angles less than 180°, while concave polygons have at least one interior angle greater than 180°.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Types of Polygons",
            "Why is classifying polygons important in geometry?",
            "It helps identify properties, calculate measurements, and solve geometric problems.",
            "It only changes the names of shapes.",
            "It removes the need for formulas.",
            "It is only useful for drawing.",
            QuestionOption.A,
            "Polygon classification helps understand relationships between shapes and is used in mathematics, design, engineering, and architecture.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications of Polygons
        // ==========================================================

        AddQuestion(
            "Applications of Polygons",
            "Why are polygons commonly used in architecture and construction?",
            "They help design structures, patterns, and stable geometric layouts.",
            "They cannot represent real objects.",
            "They are only used for decoration.",
            "They do not have measurable properties.",
            QuestionOption.A,
            "Polygons are used in architecture to create building designs, floor plans, patterns, and structural layouts.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Polygons",
            "Computer graphics use polygons to create 3D models. Why are polygons useful?",
            "They can represent complex surfaces using connected shapes.",
            "They cannot be processed by computers.",
            "They only work for 2D drawings.",
            "They remove the need for calculations.",
            QuestionOption.A,
            "3D graphics use polygon meshes to represent objects efficiently by combining many small polygon surfaces.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Polygons",
            "Maps and geographic systems use polygons to represent areas. What can a polygon represent on a map?",
            "Regions, boundaries, and land areas.",
            "Only individual points.",
            "Only straight lines.",
            "Only numerical values.",
            QuestionOption.A,
            "In mapping systems, polygons are used to represent countries, cities, properties, lakes, and other defined regions.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Polygons",
            "Why are regular polygons useful in design and engineering?",
            "Their equal sides and angles create balanced and predictable patterns.",
            "They cannot be measured.",
            "They always have curved edges.",
            "They cannot form structures.",
            QuestionOption.A,
            "Regular polygons provide symmetry and consistency, making them useful in engineering, design, and manufacturing.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Polygons",
            "Why are polygons important in advanced mathematics and technology?",
            "They help model shapes, analyze structures, create graphics, and solve geometric problems.",
            "They are only used in basic drawings.",
            "They have no connection to technology.",
            "They cannot be used for measurements.",
            QuestionOption.A,
            "Polygons are fundamental in computer graphics, architecture, engineering, robotics, and mathematical modelling.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Circles
        // ==========================================================

        AddQuestion(
            "Introduction to Circles",
            "What is a circle?",
            "A polygon with four sides",
            "A closed two-dimensional shape where all points are the same distance from the center",
            "A three-dimensional solid shape",
            "A shape made only of straight lines",
            QuestionOption.B,
            "A circle is a closed two-dimensional figure where every point on its boundary is at an equal distance from the center.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Circles",
            "What is the fixed point inside a circle called?",
            "Radius",
            "Diameter",
            "Center",
            "Chord",
            QuestionOption.C,
            "The center is the fixed point from which all points on the circle are equally distant.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Circles",
            "What is the distance from the center of a circle to any point on its boundary called?",
            "Diameter",
            "Radius",
            "Circumference",
            "Arc",
            QuestionOption.B,
            "The radius is the distance between the center of a circle and any point on its circumference.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Circles",
            "Which part of a circle passes through the center and connects two points on the circle?",
            "Chord",
            "Arc",
            "Diameter",
            "Sector",
            QuestionOption.C,
            "A diameter is a line segment that passes through the center and connects two points on the circle. It is twice the length of the radius.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Circles",
            "Why are circles important in real-world applications?",
            "They are only used in mathematics textbooks.",
            "They are used in wheels, machines, architecture, engineering, and design.",
            "They cannot represent real objects.",
            "They only help calculate angles.",
            QuestionOption.B,
            "Circles are widely used in engineering, transportation, mechanical systems, architecture, and many everyday objects because of their symmetry and properties.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Parts and Properties of Circles
        // ==========================================================

        AddQuestion(
            "Parts and Properties of Circles",
            "What is the fixed point at the center of a circle called?",
            "Radius",
            "Center",
            "Chord",
            "Arc",
            QuestionOption.B,
            "The center is the fixed point from which all points on the circle are at the same distance.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Parts and Properties of Circles",
            "What is the distance from the center of a circle to any point on its circumference called?",
            "Diameter",
            "Radius",
            "Tangent",
            "Sector",
            QuestionOption.B,
            "The radius is the distance from the center to any point on the circle, and the diameter is twice the radius.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Parts and Properties of Circles",
            "A line segment that passes through the center of a circle and connects two points on the circumference is called:",
            "Chord",
            "Arc",
            "Diameter",
            "Secant",
            QuestionOption.C,
            "A diameter is the longest chord of a circle and passes through the center.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Parts and Properties of Circles",
            "What is a line that touches a circle at exactly one point called?",
            "Secant",
            "Chord",
            "Tangent",
            "Radius",
            QuestionOption.C,
            "A tangent touches the circle at one point, called the point of contact.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Parts and Properties of Circles",
            "Why are understanding the parts and properties of circles important?",
            "They help solve geometric problems involving measurements, angles, and circular structures.",
            "They are only useful for drawing circles.",
            "They cannot be applied outside mathematics.",
            "They replace all geometry concepts.",
            QuestionOption.A,
            "Circle properties are used in engineering, architecture, physics, design, and many real-world applications involving circular objects.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Circles
        // ==========================================================

        AddQuestion(
            "Applications of Circles",
            "Why are circles commonly used in wheels and gears?",
            "They provide smooth rotation around a fixed center.",
            "They cannot be measured accurately.",
            "They only work in drawings.",
            "They prevent movement.",
            QuestionOption.A,
            "Circles are ideal for rotational motion because every point on the edge is equally distant from the center.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Circles",
            "Astronomers use circular paths to describe the motion of planets. Which circle property is useful?",
            "Distance from the center remains constant.",
            "All circles have different centers.",
            "Circles have no measurements.",
            "Circles cannot represent movement.",
            QuestionOption.A,
            "Circular motion is based on the constant distance between an object and the center of rotation.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Circles",
            "Engineers use circles in mechanical designs. Why are circular shapes useful?",
            "They allow efficient rotation and balanced distribution of forces.",
            "They cannot be calculated.",
            "They only represent flat objects.",
            "They have no practical purpose.",
            QuestionOption.A,
            "Circular components such as wheels, bearings, and gears rely on circle properties for efficient operation.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Circles",
            "A satellite dish uses a circular shape. Which property helps it work effectively?",
            "The circular design helps collect and focus signals symmetrically.",
            "It prevents all signals from reaching the dish.",
            "It removes the need for technology.",
            "It only works for decoration.",
            QuestionOption.A,
            "Circular shapes are used in antennas and dishes because of their symmetry and reflective properties.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Circles",
            "Why are circles important in advanced mathematics and technology?",
            "They are used in engineering, physics, astronomy, graphics, and many mathematical models.",
            "They are only used for classroom drawings.",
            "They cannot represent real-world objects.",
            "They are unrelated to measurements.",
            QuestionOption.A,
            "Circle concepts are fundamental in fields such as robotics, transportation, astronomy, mechanical design, and computer graphics.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Introduction to Geometric Constructions
        // ==========================================================

        AddQuestion(
            "Introduction to Geometric Constructions",
            "What are geometric constructions?",
            "Drawing random shapes without measurements",
            "Creating accurate geometric figures using specific tools and methods",
            "Calculating only the area of shapes",
            "Measuring temperature using instruments",
            QuestionOption.B,
            "Geometric constructions involve creating accurate geometric figures using tools such as a compass and straightedge following specific rules.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Geometric Constructions",
            "Which two tools are traditionally used for geometric constructions?",
            "Calculator and ruler",
            "Compass and straightedge",
            "Protractor and calculator",
            "Pencil and eraser only",
            QuestionOption.B,
            "A compass and straightedge are the traditional tools used to create precise geometric constructions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Geometric Constructions",
            "What is the main purpose of using a compass in geometric constructions?",
            "To measure angles directly",
            "To draw circles and arcs with a fixed radius",
            "To calculate areas",
            "To create curved equations",
            QuestionOption.B,
            "A compass is used to draw circles and arcs while maintaining a fixed distance from a point.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Geometric Constructions",
            "Which of the following can be constructed using geometric methods?",
            "A perfectly measured angle bisector",
            "A random freehand drawing",
            "A photograph",
            "A digital animation only",
            QuestionOption.A,
            "Geometric construction methods can accurately create objects such as angle bisectors, perpendicular lines, and triangles.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Geometric Constructions",
            "Why are geometric constructions important in real-world fields?",
            "They remove the need for precision.",
            "They help create accurate designs in architecture, engineering, and technical drawings.",
            "They are only useful for solving puzzles.",
            "They are only used to draw circles.",
            QuestionOption.B,
            "Geometric constructions provide accuracy and precision, making them useful in architecture, engineering, design, and manufacturing.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Common Geometric Constructions
        // ==========================================================

        AddQuestion(
            "Common Geometric Constructions",
            "Which two tools are traditionally used for geometric constructions?",
            "Ruler and calculator",
            "Compass and straightedge",
            "Protractor and calculator",
            "Computer and printer",
            QuestionOption.B,
            "Classical geometric constructions are performed using a compass and straightedge.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Common Geometric Constructions",
            "What is the purpose of constructing an angle bisector?",
            "To divide an angle into two equal parts.",
            "To increase the size of an angle.",
            "To remove an angle.",
            "To create a circle.",
            QuestionOption.A,
            "An angle bisector divides an angle into two congruent angles.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Common Geometric Constructions",
            "What does a perpendicular line form when it intersects another line?",
            "A 90° angle",
            "A 180° angle",
            "A curved shape",
            "An unequal angle only",
            QuestionOption.A,
            "Perpendicular lines intersect at a right angle of 90°.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Common Geometric Constructions",
            "Why is a compass used in geometric constructions?",
            "To draw arcs and create equal distances from points.",
            "To measure temperature.",
            "To calculate equations automatically.",
            "To draw only straight lines.",
            QuestionOption.A,
            "A compass helps construct circles, arcs, and equal-length segments accurately.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Common Geometric Constructions",
            "Why are geometric constructions important in mathematics and engineering?",
            "They provide accurate methods for creating and analyzing geometric figures.",
            "They only apply to simple drawings.",
            "They cannot be used for real designs.",
            "They replace all mathematical formulas.",
            QuestionOption.A,
            "Geometric constructions are used in design, architecture, engineering, and mathematical proofs.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Geometric Constructions
        // ==========================================================

        AddQuestion(
            "Applications of Geometric Constructions",
            "Why are geometric constructions useful in architecture?",
            "They help create accurate designs, layouts, and structural plans.",
            "They remove the need for measurements.",
            "They only work for drawings.",
            "They cannot represent buildings.",
            QuestionOption.A,
            "Architects use geometric constructions to create precise designs, floor plans, and structural models.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Geometric Constructions",
            "Surveyors use geometric constructions to determine locations and distances. Which concept is commonly applied?",
            "Accurate geometric measurement and construction",
            "Polynomial expansion",
            "Probability calculation",
            "Number classification",
            QuestionOption.A,
            "Surveying uses geometric methods to measure land, establish boundaries, and determine positions accurately.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Geometric Constructions",
            "Technical drawings use geometric constructions because they:",
            "Allow precise representation of objects and components.",
            "Prevent accurate measurements.",
            "Only create artistic sketches.",
            "Remove the need for geometry.",
            QuestionOption.A,
            "Engineering and technical drawings require precise geometric constructions to represent real objects correctly.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Geometric Constructions",
            "Computer-aided design (CAD) software uses geometric constructions to:",
            "Create accurate digital models and engineering designs.",
            "Avoid using mathematical principles.",
            "Only draw random shapes.",
            "Replace all engineering calculations.",
            QuestionOption.A,
            "CAD systems rely on geometric principles to create precise models used in engineering, manufacturing, and design.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Geometric Constructions",
            "Why are geometric constructions important in advanced fields?",
            "They provide accurate methods for designing, modelling, analysing, and solving geometric problems.",
            "They are only useful in school exercises.",
            "They cannot be applied in technology.",
            "They only involve simple drawings.",
            QuestionOption.A,
            "Geometric constructions are fundamental in architecture, engineering, robotics, surveying, and computer modelling.",
            DifficultyLevel.Advance,
            5);











        // ==========================================================
        // Introduction to Area
        // ==========================================================

        AddQuestion(
            "Introduction to Area",
            "What does area measure in geometry?",
            "The distance around a shape",
            "The space enclosed inside a two-dimensional shape",
            "The number of sides of a shape",
            "The angle between two lines",
            QuestionOption.B,
            "Area measures the amount of space covered or enclosed by a two-dimensional shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Area",
            "What is the standard unit used to measure area?",
            "Metres (m)",
            "Square metres (m²)",
            "Cubic metres (m³)",
            "Degrees (°)",
            QuestionOption.B,
            "Area is measured in square units such as square metres (m²), square centimetres (cm²), and square kilometres (km²).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Area",
            "Which formula is used to calculate the area of a rectangle?",
            "Length + Width",
            "2 × (Length + Width)",
            "Length × Width",
            "Length ÷ Width",
            QuestionOption.C,
            "The area of a rectangle is calculated by multiplying its length by its width.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Area",
            "If a square has a side length of 5 cm, what is its area?",
            "10 cm²",
            "20 cm²",
            "25 cm²",
            "30 cm²",
            QuestionOption.C,
            "The area of a square is side × side. Therefore, 5 × 5 = 25 cm².",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Area",
            "Why is understanding area important in real-world applications?",
            "It helps measure spaces needed for construction, design, and planning.",
            "It only helps draw geometric shapes.",
            "It replaces all other mathematical measurements.",
            "It is only used in classroom exercises.",
            QuestionOption.A,
            "Area calculations are used in architecture, engineering, construction, land measurement, interior design, and many practical situations.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Area of Common Shapes
        // ==========================================================

        AddQuestion(
            "Area of Common Shapes",
            "What does the area of a shape represent?",
            "The amount of space enclosed inside the shape.",
            "The distance around the shape.",
            "The number of sides of the shape.",
            "The angles of the shape only.",
            QuestionOption.A,
            "Area measures the amount of surface enclosed within a two-dimensional shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Area of Common Shapes",
            "What is the formula for finding the area of a rectangle?",
            "Length × Width",
            "2 × (Length + Width)",
            "Side × Side × Side",
            "Base + Height",
            QuestionOption.A,
            "The area of a rectangle is calculated by multiplying its length by its width.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Area of Common Shapes",
            "Which formula is used to calculate the area of a triangle?",
            "Base × Height",
            "(1/2) × Base × Height",
            "Side × Side",
            "π × Radius",
            QuestionOption.B,
            "The area of a triangle is half the product of its base and perpendicular height.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Area of Common Shapes",
            "The area of a circle depends on which measurements?",
            "Radius",
            "Diameter only",
            "Number of sides",
            "Perimeter only",
            QuestionOption.A,
            "The area of a circle is calculated using π multiplied by the square of its radius.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Area of Common Shapes",
            "Why is calculating the area of different shapes important?",
            "It helps solve problems in construction, design, engineering, and real-world measurements.",
            "It is only used for naming shapes.",
            "It removes the need for geometry.",
            "It only applies to drawings.",
            QuestionOption.A,
            "Area calculations are essential in architecture, construction, land measurement, manufacturing, and many practical applications.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Applications of Area
        // ==========================================================

        AddQuestion(
            "Applications of Area",
            "Why is calculating area important in construction?",
            "It helps determine the amount of materials needed for surfaces and structures.",
            "It removes the need for measurements.",
            "It only helps name shapes.",
            "It cannot be applied to buildings.",
            QuestionOption.A,
            "Builders use area calculations to estimate materials such as flooring, paint, tiles, and land coverage.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Area",
            "Farmers use area calculations mainly to determine:",
            "The size of farmland and required resources.",
            "The number of angles in a field.",
            "The color of crops.",
            "The shape of clouds.",
            QuestionOption.A,
            "Area helps farmers measure land size, plan cultivation, and estimate resource requirements.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Area",
            "Architects calculate the area of rooms and surfaces to:",
            "Design spaces and estimate material requirements accurately.",
            "Avoid using measurements.",
            "Remove geometric calculations.",
            "Only create drawings.",
            QuestionOption.A,
            "Area calculations help architects plan floor spaces, wall surfaces, and building layouts.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Area",
            "Computer graphics use area calculations for:",
            "Rendering surfaces, textures, and visual elements.",
            "Removing all geometry from graphics.",
            "Only creating text.",
            "Avoiding measurements.",
            QuestionOption.A,
            "Graphics systems use geometric area calculations when displaying and processing digital objects.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Area",
            "Why is understanding area important in advanced fields?",
            "It helps solve real-world problems involving space, resources, design, and measurement.",
            "It only applies to basic geometry lessons.",
            "It cannot be used outside mathematics.",
            "It replaces all other calculations.",
            QuestionOption.A,
            "Area concepts are fundamental in engineering, architecture, science, geography, agriculture, and technology.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Introduction to Perimeter
        // ==========================================================

        AddQuestion(
            "Introduction to Perimeter",
            "What does perimeter measure in geometry?",
            "The space inside a shape",
            "The total distance around the boundary of a shape",
            "The number of angles in a shape",
            "The height of a shape",
            QuestionOption.B,
            "Perimeter measures the total distance around the outside boundary of a two-dimensional shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Perimeter",
            "What unit is commonly used to measure perimeter?",
            "Square units",
            "Cubic units",
            "Linear units",
            "Degrees",
            QuestionOption.C,
            "Perimeter is a length measurement, so it is measured using linear units such as metres (m) or centimetres (cm).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Perimeter",
            "How do you find the perimeter of a rectangle?",
            "Length × Width",
            "Add all four sides together",
            "Length ÷ Width",
            "Side × Side",
            QuestionOption.B,
            "The perimeter of a rectangle is found by adding the lengths of all four sides, or using 2 × (length + width).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Perimeter",
            "A square has sides of length 6 cm. What is its perimeter?",
            "12 cm",
            "18 cm",
            "24 cm",
            "36 cm",
            QuestionOption.C,
            "A square has four equal sides, so the perimeter is 4 × 6 = 24 cm.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Perimeter",
            "Why is understanding perimeter useful in real-world applications?",
            "It helps calculate boundaries for fencing, construction, and design.",
            "It is only used to find the area of shapes.",
            "It removes the need for measurements.",
            "It is only useful for circles.",
            QuestionOption.A,
            "Perimeter is used in practical situations such as finding the amount of fencing needed, measuring borders, and planning construction layouts.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Calculating the Perimeter of Shapes
        // ==========================================================

        AddQuestion(
            "Calculating the Perimeter of Shapes",
            "What does the perimeter of a shape represent?",
            "The total distance around the boundary of the shape.",
            "The space inside the shape.",
            "The number of angles in the shape.",
            "The size of the shape's area.",
            QuestionOption.A,
            "Perimeter measures the complete distance around the outside edge of a two-dimensional shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Calculating the Perimeter of Shapes",
            "How is the perimeter of a rectangle calculated?",
            "Length × Width",
            "2 × (Length + Width)",
            "Base × Height",
            "π × Radius²",
            QuestionOption.B,
            "A rectangle has two equal lengths and two equal widths, so its perimeter is 2 × (Length + Width).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Calculating the Perimeter of Shapes",
            "What is the perimeter formula for a square?",
            "4 × Side length",
            "Side length²",
            "2 × Side length",
            "Length × Width",
            QuestionOption.A,
            "A square has four equal sides, so its perimeter is four times the length of one side.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Calculating the Perimeter of Shapes",
            "How is the perimeter of a circle calculated?",
            "π × Radius²",
            "2 × π × Radius",
            "Length × Width",
            "Base × Height",
            QuestionOption.B,
            "The perimeter of a circle is called circumference and is calculated using 2πr.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Calculating the Perimeter of Shapes",
            "Why is calculating perimeter important in real-world applications?",
            "It helps measure boundaries, fencing, borders, construction materials, and object dimensions.",
            "It only helps identify shapes.",
            "It removes the need for measurements.",
            "It is only useful for drawings.",
            QuestionOption.A,
            "Perimeter calculations are used in construction, land measurement, design, manufacturing, and everyday planning.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications of Perimeter
        // ==========================================================

        AddQuestion(
            "Applications of Perimeter",
            "Why is perimeter used when building a fence around a property?",
            "It helps determine the total length of fencing material needed.",
            "It calculates the area inside the property.",
            "It determines the height of the fence only.",
            "It removes the need for measurements.",
            QuestionOption.A,
            "Perimeter measures the boundary length, which helps calculate how much fencing material is required.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Perimeter",
            "Landscapers use perimeter calculations to:",
            "Measure boundaries of gardens, parks, and outdoor spaces.",
            "Calculate the weight of plants.",
            "Determine the colour of landscapes.",
            "Replace all design planning.",
            QuestionOption.A,
            "Perimeter helps landscapers plan borders, pathways, fences, and decorative boundaries.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Perimeter",
            "Architects and engineers calculate perimeter mainly to:",
            "Design boundaries and estimate materials needed for structures.",
            "Avoid using geometric measurements.",
            "Only create drawings.",
            "Calculate only the volume of objects.",
            QuestionOption.A,
            "Perimeter calculations help estimate materials for frames, borders, walls, and structural components.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Perimeter",
            "A manufacturer creates a frame around a rectangular product. Which measurement is needed?",
            "Perimeter of the rectangle.",
            "Area of the rectangle only.",
            "Number of angles only.",
            "Diagonal length only.",
            QuestionOption.A,
            "The perimeter gives the total length of material required to create a border or frame.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Perimeter",
            "Why is understanding perimeter important in advanced fields?",
            "It helps solve real-world problems involving boundaries, construction, design, and measurement.",
            "It is only useful for simple classroom exercises.",
            "It has no connection with engineering.",
            "It cannot be applied to real objects.",
            QuestionOption.A,
            "Perimeter is widely used in architecture, engineering, geography, manufacturing, and everyday planning.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Transformations
        // ==========================================================

        AddQuestion(
            "Introduction to Transformations",
            "What are geometric transformations?",
            "Methods used to calculate the area of shapes",
            "Operations that move, flip, turn, or resize geometric figures",
            "Ways to measure angles only",
            "Techniques used to draw circles",
            QuestionOption.B,
            "Geometric transformations are operations that change the position, orientation, or size of a figure while maintaining its geometric properties.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Transformations",
            "Which transformation moves a shape from one location to another without changing its size or orientation?",
            "Rotation",
            "Reflection",
            "Translation",
            "Dilation",
            QuestionOption.C,
            "A translation slides a figure from one position to another while keeping the same shape, size, and orientation.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Transformations",
            "What happens to a figure during a reflection?",
            "It becomes larger",
            "It flips over a line to create a mirror image",
            "It changes into a different shape",
            "It loses all measurements",
            QuestionOption.B,
            "A reflection creates a mirror image of a figure across a line called the line of reflection.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Transformations",
            "Which transformation changes the size of a figure while keeping the same shape?",
            "Rotation",
            "Translation",
            "Reflection",
            "Dilation",
            QuestionOption.D,
            "A dilation enlarges or reduces a figure by a scale factor while preserving its shape.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Transformations",
            "Why are geometric transformations important in real-world applications?",
            "They are only used for solving textbook problems.",
            "They are used in computer graphics, animation, engineering, robotics, and design.",
            "They eliminate the need for measurements.",
            "They only apply to triangles.",
            QuestionOption.B,
            "Transformations are widely used in digital graphics, games, animation, architecture, robotics, and engineering to manipulate objects accurately.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Types of Transformations
        // ==========================================================

        AddQuestion(
            "Types of Transformations",
            "Which transformation moves a figure from one position to another without changing its size or shape?",
            "Translation",
            "Reflection",
            "Rotation",
            "Dilation",
            QuestionOption.A,
            "A translation slides a figure to a new position while preserving its size, shape, and orientation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Types of Transformations",
            "Which transformation creates a mirror image of a figure across a line?",
            "Rotation",
            "Reflection",
            "Translation",
            "Dilation",
            QuestionOption.B,
            "Reflection flips a figure over a line called the line of reflection, creating a mirror image.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Types of Transformations",
            "Which transformation turns a figure around a fixed point?",
            "Translation",
            "Dilation",
            "Rotation",
            "Reflection",
            QuestionOption.C,
            "Rotation turns a figure around a fixed point by a specific angle and direction.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Types of Transformations",
            "What happens to a figure during dilation?",
            "Its size changes while its shape remains the same.",
            "Its shape changes completely.",
            "It moves without changing position.",
            "It disappears from the plane.",
            QuestionOption.A,
            "Dilation enlarges or reduces a figure using a scale factor while preserving its shape.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Types of Transformations",
            "Why are geometric transformations important in mathematics and technology?",
            "They help describe movements, designs, graphics, and changes in geometric figures.",
            "They are only used for naming shapes.",
            "They cannot be applied outside geometry.",
            "They remove the need for measurements.",
            QuestionOption.A,
            "Transformations are used in computer graphics, engineering, animation, architecture, and mathematical modelling.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Transformations
        // ==========================================================

        AddQuestion(
            "Applications of Transformations",
            "Why are transformations used in computer graphics?",
            "They help move, rotate, resize, and modify digital objects.",
            "They prevent objects from being displayed.",
            "They remove the need for calculations.",
            "They only work with physical objects.",
            QuestionOption.A,
            "Computer graphics use transformations to position, scale, and animate objects in digital environments.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Transformations",
            "Animation software uses transformations to create movement. Which transformation helps rotate an object?",
            "Rotation",
            "Translation",
            "Reflection",
            "Dilation",
            QuestionOption.A,
            "Rotation transformations allow objects to turn around a fixed point, which is essential in animation.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Transformations",
            "Robotics uses transformations mainly to:",
            "Control positions, movements, and orientations of robotic parts.",
            "Remove all movement from robots.",
            "Avoid using geometry.",
            "Only create drawings.",
            QuestionOption.A,
            "Robotics relies on transformations to calculate how objects move and change position in space.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Transformations",
            "Image processing uses transformations to:",
            "Resize, rotate, adjust, and analyze digital images.",
            "Delete all image information.",
            "Prevent image modification.",
            "Only store text data.",
            QuestionOption.A,
            "Transformations are used in image editing, computer vision, and digital graphics processing.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Transformations",
            "Why are transformations important in advanced fields such as engineering and game development?",
            "They help model motion, create simulations, and represent changes in objects accurately.",
            "They only apply to simple classroom drawings.",
            "They cannot be used with technology.",
            "They replace all mathematical concepts.",
            QuestionOption.A,
            "Transformations are fundamental in CAD systems, simulations, robotics, games, animation, and 3D modelling.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Coordinate Proofs
        // ==========================================================

        AddQuestion(
            "Introduction to Coordinate Proofs",
            "What is a coordinate proof?",
            "A proof that uses only geometric drawings",
            "A method of proving geometric statements using coordinates and algebra",
            "A way to calculate only the area of shapes",
            "A technique used only for measuring angles",
            QuestionOption.B,
            "Coordinate proofs use points on a coordinate plane and algebraic methods to prove geometric properties.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Coordinate Proofs",
            "Which mathematical system is mainly used in coordinate proofs?",
            "Number line only",
            "Coordinate plane with x and y axes",
            "Clock system",
            "Three-dimensional model only",
            QuestionOption.B,
            "Coordinate proofs use the coordinate plane, which consists of horizontal x-axis and vertical y-axis, to represent geometric figures.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Coordinate Proofs",
            "Which formula can be used to find the distance between two points in a coordinate plane?",
            "Area formula",
            "Distance formula",
            "Quadratic formula",
            "Slope formula only",
            QuestionOption.B,
            "The distance formula calculates the length between two points using their coordinates.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Coordinate Proofs",
            "How can the slope of a line help in coordinate proofs?",
            "It can determine relationships such as parallel or perpendicular lines.",
            "It calculates the area of every shape.",
            "It changes a shape into a circle.",
            "It removes the need for coordinates.",
            QuestionOption.A,
            "Slope helps prove geometric relationships by showing whether lines are parallel, perpendicular, or have the same direction.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Coordinate Proofs",
            "Why are coordinate proofs useful in mathematics and real-world fields?",
            "They combine algebra and geometry to verify designs and relationships accurately.",
            "They are only used for drawing pictures.",
            "They replace all mathematical formulas.",
            "They only work with circles.",
            QuestionOption.A,
            "Coordinate proofs connect algebra with geometry and are useful in engineering, computer graphics, architecture, and analytical problem-solving.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Methods of Coordinate Proofs
        // ==========================================================

        AddQuestion(
            "Methods of Coordinate Proofs",
            "What is the main purpose of a coordinate proof?",
            "To use algebra and coordinates to prove geometric relationships.",
            "To draw shapes without measurements.",
            "To avoid using mathematical reasoning.",
            "To only calculate areas.",
            QuestionOption.A,
            "Coordinate proofs combine geometry and algebra by representing figures on a coordinate plane and verifying properties mathematically.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Methods of Coordinate Proofs",
            "Which formula is used to find the distance between two points on a coordinate plane?",
            "Midpoint formula",
            "Distance formula",
            "Slope formula",
            "Area formula",
            QuestionOption.B,
            "The distance formula calculates the length between two points using their coordinates.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Methods of Coordinate Proofs",
            "What does the midpoint formula help determine?",
            "The exact center point between two coordinates.",
            "The angle between two lines.",
            "The area of a circle.",
            "The length of a triangle only.",
            QuestionOption.A,
            "The midpoint formula finds the point exactly halfway between two endpoints.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Methods of Coordinate Proofs",
            "How is slope useful in coordinate proofs?",
            "It helps determine the relationship between lines, such as parallel or perpendicular.",
            "It calculates the area of any shape directly.",
            "It replaces all geometric concepts.",
            "It only measures distances.",
            QuestionOption.A,
            "Slope is used to compare line directions and prove relationships between geometric figures.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Methods of Coordinate Proofs",
            "Why are coordinate proof methods important in advanced mathematics?",
            "They provide systematic ways to verify geometric properties using algebraic reasoning.",
            "They only apply to simple drawings.",
            "They cannot be used in technology.",
            "They remove the need for mathematical proofs.",
            QuestionOption.A,
            "Coordinate proofs are used in geometry, engineering, computer graphics, and analytical mathematics.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Applications of Coordinate Proofs
        // ==========================================================

        AddQuestion(
            "Applications of Coordinate Proofs",
            "Why are coordinate proofs useful in engineering?",
            "They help verify designs, measurements, and geometric relationships accurately.",
            "They remove the need for calculations.",
            "They only create artistic drawings.",
            "They cannot represent real structures.",
            QuestionOption.A,
            "Engineers use coordinate methods to analyze structures, positions, and geometric properties of designs.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Coordinate Proofs",
            "Architects use coordinate proofs mainly to:",
            "Analyze layouts, positions, and relationships between design elements.",
            "Avoid using measurements.",
            "Replace all building materials.",
            "Only decorate drawings.",
            QuestionOption.A,
            "Coordinate systems help architects create accurate plans and verify geometric arrangements.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Coordinate Proofs",
            "Computer graphics use coordinate geometry to:",
            "Represent and manipulate objects using points and geometric relationships.",
            "Prevent objects from being displayed.",
            "Remove all mathematical calculations.",
            "Only create text elements.",
            QuestionOption.A,
            "Graphics systems use coordinates to position, transform, and model digital objects.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Coordinate Proofs",
            "Surveyors use coordinate methods to:",
            "Determine accurate locations, distances, and boundaries of land.",
            "Calculate only object colours.",
            "Avoid measuring locations.",
            "Replace maps completely.",
            QuestionOption.A,
            "Surveying relies on coordinate systems to record positions and measure real-world locations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Coordinate Proofs",
            "Why are coordinate proofs important in advanced fields?",
            "They connect algebra and geometry to solve complex design, modelling, and analysis problems.",
            "They are only useful for basic geometry exercises.",
            "They cannot be applied in technology.",
            "They replace all mathematical concepts.",
            QuestionOption.A,
            "Coordinate proofs are fundamental in engineering, robotics, CAD, computer graphics, and analytical mathematics.",
            DifficultyLevel.Advance,
            5);

        // PQ. 3
        // Introduction to Cartesian Plane

        AddQuestion(
            "Introduction to Cartesian Plane",
            "What are the two main axes used in a Cartesian plane?",
            "The x-axis and y-axis",
            "The horizontal axis and diagonal axis",
            "The radius and diameter",
            "The length and width",
            QuestionOption.A,
            "A Cartesian plane is formed by two perpendicular axes: the x-axis and y-axis.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "What is the coordinate of the origin in a Cartesian plane?",
            "(0,0)",
            "(1,1)",
            "(-1,-1)",
            "(0,1)",
            QuestionOption.A,
            "The origin is the point where the x-axis and y-axis intersect, represented as (0,0).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "How many quadrants are formed by the x-axis and y-axis?",
            "Four quadrants",
            "Two quadrants",
            "Three quadrants",
            "Five quadrants",
            QuestionOption.A,
            "The two perpendicular axes divide the Cartesian plane into four quadrants.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "In which quadrant does the point (4,5) lie?",
            "First quadrant",
            "Second quadrant",
            "Third quadrant",
            "Fourth quadrant",
            QuestionOption.A,
            "Points with positive x and positive y coordinates lie in the first quadrant.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "A point has coordinates (-3,6). Which quadrant does it belong to?",
            "Second quadrant",
            "First quadrant",
            "Third quadrant",
            "Fourth quadrant",
            QuestionOption.A,
            "A negative x-coordinate and positive y-coordinate place the point in the second quadrant.",
            DifficultyLevel.Intermediate,
            5);
        // Understanding Coordinates and Quadrants

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "What does an ordered pair (x, y) represent in a Cartesian plane?",
            "The position of a point using its x-coordinate and y-coordinate",
            "The distance between two points",
            "The angle between two lines",
            "The size of a geometric shape",
            QuestionOption.A,
            "An ordered pair represents the location of a point where x shows horizontal position and y shows vertical position.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "In which quadrant does the point (-5, 3) lie?",
            "Second quadrant",
            "First quadrant",
            "Third quadrant",
            "Fourth quadrant",
            QuestionOption.A,
            "A point with a negative x-coordinate and positive y-coordinate lies in the second quadrant.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "Which coordinate remains zero for a point located on the y-axis?",
            "The x-coordinate",
            "The y-coordinate",
            "Both coordinates",
            "Neither coordinate",
            QuestionOption.A,
            "Any point on the y-axis has an x-coordinate of zero.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "A point has coordinates (−4, −7). Which quadrant does it belong to?",
            "Third quadrant",
            "First quadrant",
            "Second quadrant",
            "Fourth quadrant",
            QuestionOption.A,
            "Points with both negative x and negative y coordinates are located in the third quadrant.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "Which point lies in the fourth quadrant?",
            "(3, -6)",
            "(-3, 6)",
            "(-5, -2)",
            "(4, 7)",
            QuestionOption.A,
            "The fourth quadrant contains points with positive x-coordinates and negative y-coordinates.",
            DifficultyLevel.Intermediate,
            5);
        // Applications and Practice of Cartesian Plane

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "Why is the Cartesian plane useful in real-world applications?",
            "It helps represent locations, movements, and relationships using coordinates.",
            "It is only used for basic arithmetic calculations.",
            "It removes the need for measurements.",
            "It can only represent circles.",
            QuestionOption.A,
            "The Cartesian plane is widely used in maps, engineering, computer graphics, and data analysis to represent positions and relationships.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "A drone moves from point (2,3) to point (7,3). In which direction does it move?",
            "Horizontally to the right",
            "Vertically upward",
            "Diagonally downward",
            "Vertically downward",
            QuestionOption.A,
            "The y-coordinate remains the same while the x-coordinate increases, showing horizontal movement to the right.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "A city map uses coordinates to mark locations. What mathematical concept is being applied?",
            "Coordinate geometry",
            "Algebraic factorization",
            "Trigonometric identities",
            "Probability theory",
            QuestionOption.A,
            "Coordinate geometry uses points and coordinates to represent locations and solve spatial problems.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "A point moves from (−2,4) to (−2,−5). What type of movement occurs?",
            "Vertical movement downward",
            "Horizontal movement right",
            "Horizontal movement left",
            "No movement",
            QuestionOption.A,
            "The x-coordinate remains constant while the y-coordinate decreases, indicating downward vertical movement.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "How are Cartesian coordinates used in computer graphics?",
            "They help position and transform objects on a screen.",
            "They are only used to calculate probabilities.",
            "They replace programming languages.",
            "They are used only for measuring angles.",
            QuestionOption.A,
            "Computer graphics rely on coordinate systems to place, move, rotate, and scale objects digitally.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Distance Formula

        AddQuestion(
            "Introduction to Distance Formula",
            "What is the distance formula used to find?",
            "The distance between two points on a coordinate plane",
            "The midpoint of a line segment",
            "The slope of a line",
            "The area of a triangle",
            QuestionOption.A,
            "The distance formula calculates the length of the line segment joining two points in a coordinate plane.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Distance Formula",
            "Which theorem is used to derive the distance formula?",
            "Pythagorean theorem",
            "Angle sum theorem",
            "Similarity theorem",
            "Binomial theorem",
            QuestionOption.A,
            "The distance formula is derived by applying the Pythagorean theorem to the horizontal and vertical differences between two points.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Distance Formula",
            "What are the coordinates of two points generally represented as in the distance formula?",
            "(x₁, y₁) and (x₂, y₂)",
            "(a, b) and (c, d)",
            "(x, y) and (r, θ)",
            "(l, w) and (h, k)",
            QuestionOption.A,
            "The distance formula uses two points represented as (x₁, y₁) and (x₂, y₂).",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Distance Formula",
            "If two points have the same x-coordinate, what type of line segment connects them?",
            "Vertical line segment",
            "Horizontal line segment",
            "Curved line segment",
            "No line segment",
            QuestionOption.A,
            "When x-coordinates are equal, the points lie on the same vertical line.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Distance Formula",
            "Why is the distance formula important in coordinate geometry?",
            "It helps measure lengths between points using coordinates",
            "It calculates only angles between lines",
            "It replaces all geometric formulas",
            "It is only used for circles",
            QuestionOption.A,
            "The distance formula connects algebra and geometry by allowing lengths to be calculated from coordinate values.",
            DifficultyLevel.Begineer,
            5);

        // Solving Problems Using Distance Formula

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "Find the distance between the points (0,0) and (3,4).",
            "5 units",
            "6 units",
            "7 units",
            "4 units",
                        QuestionOption.A,
            "Using the distance formula: √((3-0)² + (4-0)²) = √(9+16) = √25 = 5 units.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "What is the distance between the points (2,3) and (6,6)?",
            "5 units",
            "4 units",
            "6 units",
            "7 units",
                        QuestionOption.A,
            "The distance is √((6-2)² + (6-3)²) = √(16+9) = √25 = 5 units.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "The points A(1,2) and B(1,8) lie on the same vertical line. What is the distance between them?",
            "6 units",
            "7 units",
            "5 units",
            "8 units",
                        QuestionOption.A,
            "Since the x-coordinates are the same, the distance is the difference between y-coordinates: |8-2| = 6 units.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "Find the distance between the points (-2,-3) and (4,5).",
            "10 units",
            "8 units",
            "12 units",
            "6 units",
                        QuestionOption.A,
            "Using the distance formula: √((4+2)² + (5+3)²) = √(36+64) = √100 = 10 units.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "A point is moved from (3,5) to (9,13). What is the length of the movement?",
            "10 units",
            "8 units",
            "12 units",
            "14 units",
            QuestionOption.A,
            "The movement distance is √((9-3)² + (13-5)²) = √(36+64) = 10 units.",
            DifficultyLevel.Intermediate,
            5);

        // Applications and Practice of Distance Formula

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "Why is the distance formula used in engineering and design applications?",
            "It helps calculate accurate distances between points in models and layouts.",
            "It only measures angles between objects.",
            "It replaces coordinate systems completely.",
            "It is used only for basic arithmetic.",
            QuestionOption.A,
            "Engineers and designers use coordinate distances to measure lengths, positions, and spatial relationships in models.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "A robot moves from position (2,4) to (8,12) on a coordinate map. What distance does it travel?",
            "10 units",
            "8 units",
            "12 units",
            "14 units",
            QuestionOption.A,
            "Using the distance formula: √((8-2)² + (12-4)²) = √(36+64) = √100 = 10 units.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "How can the distance formula help in map-based applications?",
            "It calculates the distance between two locations represented by coordinates.",
            "It determines only the direction of movement.",
            "It calculates population growth.",
            "It measures only angles.",
            QuestionOption.A,
            "Maps and navigation systems use coordinate distances to estimate real-world distances between locations.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "Two points on a blueprint are located at (-3,4) and (5,-2). What is the distance between them?",
            "10 units",
            "8 units",
            "12 units",
            "14 units",
            QuestionOption.A,
            "Distance = √((5+3)² + (-2-4)²) = √(64+36) = √100 = 10 units.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "Why is the distance formula considered a connection between algebra and geometry?",
            "It uses algebraic coordinates to solve geometric distance problems.",
            "It removes the need for geometric reasoning.",
            "It is only used for algebraic equations.",
            "It cannot be applied outside mathematics.",
            QuestionOption.A,
            "The distance formula converts geometric measurements into algebraic calculations using coordinates.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Midpoint Formula

        AddQuestion(
            "Introduction to Midpoint Formula",
            "Which formula is used to find the midpoint between two points?",
            "M = ((x₁ + x₂) / 2, (y₁ + y₂) / 2)",
            "M = (x₂ - x₁, y₂ - y₁)",
            "M = √((x₂-x₁)²+(y₂-y₁)²)",
            "M = (x₁ × x₂, y₁ × y₂)",
            QuestionOption.A,
            "The midpoint formula finds the average of the x-coordinates and y-coordinates of two endpoints.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "What does the midpoint of a line segment represent?",
            "The point exactly halfway between two endpoints",
            "The longest distance between two points",
            "The angle formed by two lines",
            "The slope of the line segment",
            QuestionOption.A,
            "A midpoint divides a line segment into two equal parts.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "If the endpoints of a line segment are (x₁,y₁) and (x₂,y₂), what values are averaged to find the midpoint?",
            "The x-coordinates and y-coordinates separately",
            "Only the x-coordinates",
            "Only the y-coordinates",
            "The distances between points",
            QuestionOption.A,
            "The midpoint is calculated by averaging the x-values and averaging the y-values.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "The midpoint formula is mainly used in which branch of mathematics?",
            "Coordinate Geometry",
            "Probability",
            "Statistics",
            "Trigonometry",
            QuestionOption.A,
            "The midpoint formula is a fundamental concept in coordinate geometry.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "Why is the midpoint formula considered useful?",
            "It helps locate the center point of a segment using coordinates",
            "It calculates the area of any shape",
            "It finds only angles",
            "It converts coordinates into measurements",
            QuestionOption.A,
            "The midpoint formula allows us to find exact central positions between two points.",
            DifficultyLevel.Begineer,
            5);


        // Solving Problems Using Midpoint Formula

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "Find the midpoint of the points (4,6) and (8,10).",
            "(6,8)",
            "(12,16)",
            "(4,4)",
            "(2,2)",
            QuestionOption.B,
            "Midpoint = ((4+8)/2, (6+10)/2) = (6,8).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "Find the midpoint of (-2,5) and (6,9).",
            "(2,7)",
            "(4,14)",
            "(8,4)",
            "(-4,2)",
            QuestionOption.A,
            "Midpoint = ((-2+6)/2, (5+9)/2) = (2,7).",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "The midpoint of two points is (5,4). One endpoint is (2,3). Find the other endpoint.",
            "(8,5)",
            "(7,6)",
            "(3,1)",
            "(10,8)",
            QuestionOption.A,
            "Using midpoint relation: x₂ = 2(5)-2 = 8 and y₂ = 2(4)-3 = 5.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "What is the midpoint of the points (-6,-4) and (2,8)?",
            "(-2,2)",
            "(4,4)",
            "(-4,6)",
            "(2,-2)",
            QuestionOption.A,
            "Midpoint = ((-6+2)/2, (-4+8)/2) = (-2,2).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "A line segment has endpoints (10,2) and (10,12). What is its midpoint?",
            "(10,7)",
            "(20,14)",
            "(5,7)",
            "(10,10)",
            QuestionOption.A,
            "The x-coordinate remains 10, and the y-coordinate is averaged: (2+12)/2 = 7.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Midpoint Formula

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "How is the midpoint formula used in architecture and engineering?",
            "To find central points and balance locations in designs",
            "To calculate only angles",
            "To remove coordinate systems",
            "To measure temperature changes",
            QuestionOption.A,
            "Engineers use midpoint calculations for symmetry, balance, and positioning structures.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "A GPS system uses two coordinate locations and calculates their midpoint. What does this represent?",
            "The location halfway between the two points",
            "The total distance between points",
            "The direction of movement",
            "The area between locations",
            QuestionOption.A,
            "The midpoint represents the exact center location between two coordinate positions.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "In computer graphics, midpoint calculations help with:",
            "Positioning and transforming objects",
            "Calculating sound waves",
            "Measuring electrical power",
            "Creating random values",
            QuestionOption.A,
            "Graphics systems use midpoint calculations to determine object positions and transformations.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "A designer finds the midpoint of two corners of a digital object. Why is this useful?",
            "To locate the object's center position",
            "To calculate its colour",
            "To remove its dimensions",
            "To change its coordinate system",
            QuestionOption.A,
            "The midpoint helps identify the central position of an object.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "Why is the midpoint formula important in real-world coordinate applications?",
            "It connects mathematical coordinates with practical location problems",
            "It only works for textbook exercises",
            "It replaces all geometry formulas",
            "It cannot be used outside mathematics",
            QuestionOption.A,
            "The midpoint formula is used in mapping, navigation, engineering, and computer graphics.",
            DifficultyLevel.Advance,
            5);
        // Introduction to Section Formula

        AddQuestion(
            "Introduction to Section Formula",
            "What does the section formula help us find?",
            "The distance between two points",
            "The coordinates of a point dividing a line segment in a given ratio",
            "The slope of a line",
            "The angle between two lines",
            QuestionOption.B,
            "The section formula is used to find the coordinates of a point that divides a line segment internally or externally in a given ratio.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Section Formula",
            "In internal division, where is the dividing point located?",
            "Between the two endpoints of the line segment",
            "Outside the line segment",
            "Always at the origin",
            "Only on the x-axis",
            QuestionOption.A,
            "Internal division means the point lies between the two given endpoints.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Section Formula",
            "Which information is required to apply the section formula?",
            "Only the slope of the line",
            "Only one coordinate point",
            "Two endpoints and the ratio of division",
            "Only the length of the segment",
            QuestionOption.C,
            "The section formula requires coordinates of both endpoints and the ratio in which the segment is divided.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Section Formula",
            "Section formula is a concept mainly studied under:",
            "Probability",
            "Statistics",
            "Trigonometry",
            "Coordinate Geometry",
            QuestionOption.D,
            "Section formula is an important topic in coordinate geometry.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Section Formula",
            "What does a ratio like 2:3 represent in section formula?",
            "The angle between two points",
            "How the line segment is divided",
            "The distance from origin",
            "The slope value",
            QuestionOption.B,
            "The ratio shows the relative lengths of the two parts created by the dividing point.",
            DifficultyLevel.Begineer,
            5);


        // Solving Problems Using Section Formula

        AddQuestion(
            "Solving Problems Using Section Formula",
            "Find the point dividing (2,4) and (8,10) internally in the ratio 1:1.",
            "(5,7)",
            "(6,8)",
            "(4,6)",
            "(3,5)",
            QuestionOption.A,
            "Ratio 1:1 gives the midpoint: ((2+8)/2, (4+10)/2) = (5,7).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "Find the point dividing (0,0) and (6,9) internally in the ratio 1:2.",
            "(4,6)",
            "(2,3)",
            "(3,4)",
            "(1,2)",
            QuestionOption.B,
            "Using section formula: ((1×6+2×0)/(3), (1×9+2×0)/(3)) = (2,3).",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "The midpoint of a line segment is a special case of section formula with ratio:",
            "2:3",
            "3:4",
            "1:1",
            "1:2",
            QuestionOption.C,
            "When the ratio is 1:1, the point divides the segment into two equal parts and becomes the midpoint.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "Find the point dividing (-4,2) and (6,12) in ratio 1:1.",
            "(2,8)",
            "(-1,6)",
            "(0,5)",
            "(1,7)",
            QuestionOption.D,
            "The midpoint is ((-4+6)/2, (2+12)/2) = (1,7).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "Which formula is used to find internal division point?",
            "((mx₂+nx₁)/(m+n), (my₂+ny₁)/(m+n))",
            "√((x₂-x₁)²+(y₂-y₁)²)",
            "((x₁+x₂),(y₁+y₂))",
            "y = mx + c",
            QuestionOption.A,
            "The internal section formula uses weighted averages of the endpoint coordinates.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Section Formula

        AddQuestion(
            "Applications and Practice of Section Formula",
            "Why is section formula useful in engineering drawings?",
            "It helps locate points at specific proportional positions",
            "It calculates only angles",
            "It removes coordinate systems",
            "It replaces all measurements",
            QuestionOption.A,
            "Engineers use section formula to locate points along structures based on ratios.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "A designer wants to find a point that divides a bridge support in a fixed ratio. Which concept is useful?",
            "Distance Formula",
            "Section Formula",
            "Slope Formula",
            "Circle Equation",
            QuestionOption.B,
            "Section formula helps find coordinates of points dividing a segment in a given ratio.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "How is section formula applied in computer graphics?",
            "By placing objects at proportional positions",
            "By calculating sound frequencies",
            "By removing coordinate systems",
            "By measuring only angles",
            QuestionOption.A,
            "Graphics applications use coordinate ratios for positioning and transformations.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "A map shows two locations and needs a point exactly halfway between them. Which method can be used?",
            "Distance formula only",
            "Slope formula only",
            "Section formula with ratio 1:1",
            "Area formula",
            QuestionOption.C,
            "A midpoint is obtained using section formula with a 1:1 ratio.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "Why is section formula important in coordinate geometry?",
            "It connects ratios with coordinate positions",
            "It works only for circles",
            "It replaces geometry completely",
            "It cannot be used practically",
            QuestionOption.A,
            "Section formula connects algebraic ratios with geometric positions on a coordinate plane.",
            DifficultyLevel.Advance,
            5);


        // Introduction to Straight Line

        AddQuestion(
            "Introduction to Straight Line",
            "What is a straight line in coordinate geometry?",
            "A line that extends infinitely in both directions with a constant slope",
            "A closed geometric figure",
            "A curve with changing slope",
            "A line segment with fixed length",
            QuestionOption.A,
            "A straight line has a constant slope and can be represented using an equation on the coordinate plane.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Straight Line",
            "Which equation represents the general form of a straight line?",
            "y = mx + c",
            "x² + y² = r²",
            "a² + b² = c²",
            "y = x²",
            QuestionOption.A,
            "The equation y = mx + c represents a straight line where m is the slope and c is the y-intercept.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Straight Line",
            "What does the slope of a straight line represent?",
            "The rate of change between y and x",
            "The length of the line",
            "The area below the line",
            "The angle of a triangle",
            QuestionOption.A,
            "Slope measures how much y changes for a change in x.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Straight Line",
            "A straight line with positive slope moves in which direction?",
            "Upward from left to right",
            "Downward from left to right",
            "Only vertically",
            "Only horizontally",
            QuestionOption.A,
            "A positive slope means the line rises as it moves from left to right.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Straight Line",
            "The point where a line crosses the y-axis is called:",
            "Y-intercept",
            "X-intercept",
            "Origin",
            "Slope",
            QuestionOption.A,
            "The y-intercept is the value of y when x equals zero.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Straight Lines

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "Find the slope of the line passing through (2,3) and (6,11).",
            "2",
            "3",
            "4",
            "1",
            QuestionOption.A,
            "Slope = (11-3)/(6-2) = 8/4 = 2.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "Which form of equation is known as slope-intercept form?",
            "y = mx + c",
            "ax + by + c = 0",
            "x² + y² = r²",
            "y = x²",
            QuestionOption.A,
            "Slope-intercept form directly shows slope and y-intercept values.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "What is the slope of a horizontal line?",
            "0",
            "1",
            "Undefined",
            "Infinite",
            QuestionOption.A,
            "A horizontal line has no vertical change, so its slope is zero.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "Two lines having the same slope are:",
            "Parallel lines",
            "Perpendicular lines",
            "Intersecting lines",
            "Curved lines",
            QuestionOption.A,
            "Lines with equal slopes remain the same distance apart and are parallel.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "What is the y-intercept of the line y = 3x + 5?",
            "5",
            "3",
            "8",
            "0",
            QuestionOption.A,
            "In y = mx + c, c represents the y-intercept. Here c = 5.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Straight Lines

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "Why are straight line equations useful in real-world applications?",
            "They model constant relationships between quantities",
            "They only describe circles",
            "They cannot represent data",
            "They are only used in geometry classes",
            QuestionOption.A,
            "Straight lines are used in engineering, physics, economics, and data analysis to represent linear relationships.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "A graph showing constant speed over time is usually represented by:",
            "A straight line",
            "A circle",
            "A random curve",
            "A triangle",
            QuestionOption.A,
            "Constant speed creates a linear relationship between distance and time.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "In computer graphics, straight line equations are used for:",
            "Drawing and positioning objects",
            "Calculating probability only",
            "Finding chemical formulas",
            "Measuring temperature only",
            QuestionOption.A,
            "Graphics systems use line equations for rendering shapes and paths.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "A road on a map is represented by a linear equation. What does the slope indicate?",
            "The direction and steepness of the road",
            "The colour of the road",
            "The total area of the map",
            "The population of the location",
            QuestionOption.A,
            "Slope represents the change in vertical position compared to horizontal movement.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "Why are straight lines important in coordinate geometry?",
            "They connect algebraic equations with geometric representations",
            "They replace all mathematical concepts",
            "They only work for triangles",
            "They cannot be used practically",
            QuestionOption.A,
            "Straight lines are a foundation of coordinate geometry and many real-world models.",
            DifficultyLevel.Advance,
            5);


        // Introduction to Pair of Straight Lines

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "What does a pair of straight lines represent in coordinate geometry?",
            "Two straight lines considered together as a single equation",
            "A single curved line",
            "A circle equation",
            "A quadratic graph only",
            QuestionOption.A,
            "A pair of straight lines represents two lines together using a combined equation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "A pair of straight lines can intersect at:",
            "Two different circles",
            "A common point",
            "No coordinate point",
            "Only the origin",
            QuestionOption.B,
            "Two intersecting straight lines meet at one common point.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "Which equation represents a pair of straight lines passing through the origin?",
            "ax² + 2hxy + by² = 0",
            "x² + y² = r²",
            "y = mx + c",
            "ax + by + c = 0",
            QuestionOption.A,
            "The homogeneous second-degree equation ax² + 2hxy + by² = 0 represents a pair of lines through the origin.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "Two lines that never meet are called:",
            "Intersecting lines",
            "Parallel lines",
            "Perpendicular lines",
            "Coincident lines",
            QuestionOption.B,
            "Parallel lines have the same slope and never intersect.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "The angle between two straight lines depends on their:",
            "Slopes",
            "Lengths",
            "Coordinates only",
            "Areas",
            QuestionOption.A,
            "The angle between two lines can be calculated using their slopes.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Pair of Straight Lines

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "The general equation of a pair of straight lines is:",
            "ax + by + c = 0",
            "ax² + 2hxy + by² + 2gx + 2fy + c = 0",
            "x² + y² = r²",
            "y = mx + c",
            QuestionOption.B,
            "A second-degree equation can represent a pair of straight lines under specific conditions.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "When two straight lines intersect, they have:",
            "The same slope",
            "A common point",
            "No solution",
            "Infinite distance",
            QuestionOption.B,
            "Intersecting lines share one common point.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "For two lines to be parallel, their slopes must be:",
            "Equal",
            "Opposite",
            "Zero always",
            "Undefined always",
            QuestionOption.A,
            "Parallel lines have equal slopes.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "Which condition represents perpendicular lines?",
            "m₁ = m₂",
            "m₁ + m₂ = 1",
            "m₁m₂ = -1",
            "m₁m₂ = 1",
            QuestionOption.C,
            "Two lines are perpendicular when the product of their slopes is -1.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "A pair of coincident lines means:",
            "Two lines overlap completely",
            "Two lines intersect once",
            "Two lines are perpendicular",
            "Two lines are parallel but different",
            QuestionOption.A,
            "Coincident lines represent the same line occupying the same position.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Pair of Straight Lines

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Pair of straight lines are useful in engineering because they help model:",
            "Intersections and directional relationships",
            "Only circular objects",
            "Only statistical data",
            "Random patterns",
            QuestionOption.A,
            "Engineers use pairs of lines to analyse intersections and geometric structures.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "In computer graphics, pairs of straight lines are commonly used for:",
            "Creating intersections and geometric shapes",
            "Calculating probability",
            "Generating sound waves",
            "Measuring temperature",
            QuestionOption.A,
            "Graphics systems use line intersections to construct shapes and models.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "A road junction represented by two crossing roads can be analysed using:",
            "Circle equations",
            "Pair of straight lines",
            "Area formulas",
            "Probability formulas",
            QuestionOption.B,
            "Intersecting roads can be represented mathematically as a pair of straight lines.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Why is the angle between two lines important?",
            "It helps analyse direction and intersection relationships",
            "It calculates only areas",
            "It removes coordinate systems",
            "It is unrelated to geometry",
            QuestionOption.A,
            "The angle between lines helps understand orientation and geometric relationships.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Pair of straight line concepts are applied in:",
            "Architecture, engineering, and computer modelling",
            "Only basic arithmetic",
            "Only biology",
            "Only probability",
            QuestionOption.D,
            "Pairs of lines are widely used in design, modelling, and analytical geometry.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Circle in Coordinate Geometry

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "What is the equation of a circle with centre (0,0) and radius r?",
            "x² + y² = r²",
            "y = mx + c",
            "ax + by + c = 0",
            "x = r",
            QuestionOption.A,
            "A circle centred at the origin has the standard equation x² + y² = r².",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "What does the radius of a circle represent?",
            "The distance between two points on the circle",
            "The distance from the centre to any point on the circle",
            "The slope of the circle",
            "The area inside the circle",
            QuestionOption.B,
            "The radius is the distance from the centre of the circle to any point on its boundary.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "Which point is called the centre of a circle?",
            "The point where the circle crosses the x-axis",
            "The point with maximum radius",
            "The fixed point from which all boundary points are equally distant",
            "The highest point of the circle",
            QuestionOption.C,
            "The centre is the fixed point that maintains equal distance from every point on the circle.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "A circle in coordinate geometry is mainly represented using:",
            "Slope",
            "Ratio",
            "Linear equation",
            "Equation involving centre and radius",
            QuestionOption.D,
            "Coordinate geometry represents circles using equations involving centre coordinates and radius.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "If the radius of a circle increases, the size of the circle:",
            "Increases",
            "Decreases",
            "Remains unchanged",
            "Becomes a straight line",
            QuestionOption.A,
            "A larger radius creates a larger circle.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Circle

        AddQuestion(
            "Equations and Properties of Circle",
            "What is the standard form equation of a circle with centre (h,k)?",
            "(x-h)² + (y-k)² = r²",
            "y = mx + c",
            "ax + by + c = 0",
            "x² + y² = 0",
            QuestionOption.A,
            "The standard equation represents a circle with centre (h,k) and radius r.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Circle",
            "In the circle equation, what does r represent?",
            "Centre",
            "Radius",
            "Slope",
            "Diameter",
            QuestionOption.B,
            "The value r represents the radius of the circle.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Circle",
            "The centre of the circle x² + y² = 25 is:",
            "(5,5)",
            "(25,0)",
            "(0,0)",
            "(0,5)",
            QuestionOption.C,
            "Since there are no shifted terms, the centre is the origin (0,0).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Circle",
            "The diameter of a circle with radius 7 is:",
            "7",
            "14",
            "21",
            "49",
            QuestionOption.B,
            "Diameter is twice the radius: 2 × 7 = 14.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Circle",
            "Which equation represents a circle?",
            "x² + y² = 16",
            "y = 2x + 1",
            "x + y = 5",
            "y = x²",
            QuestionOption.A,
            "An equation containing squared x and y terms with equal coefficients can represent a circle.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Circle

        AddQuestion(
            "Applications and Practice of Circle",
            "Circles in coordinate geometry are useful in:",
            "Modelling circular objects and paths",
            "Only solving inequalities",
            "Only measuring angles",
            "Only calculating slopes",
            QuestionOption.A,
            "Circle equations are used in engineering, graphics, navigation, and design.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Circle",
            "In computer graphics, circle equations are used for:",
            "Creating circular shapes and curves",
            "Writing text documents",
            "Calculating probability only",
            "Replacing coordinate systems",
            QuestionOption.A,
            "Graphics systems use circle equations to render circular objects.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Circle",
            "A satellite orbit can be approximated mathematically using:",
            "Straight line equation",
            "Circle equation",
            "Triangle formula",
            "Slope formula",
            QuestionOption.B,
            "Circular motion can often be represented using circle equations.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Circle",
            "Why are circle equations important in engineering?",
            "They help model circular components and motion",
            "They remove the need for measurements",
            "They only describe triangles",
            "They cannot be applied practically",
            QuestionOption.A,
            "Engineers use circle equations for wheels, gears, pipes, and mechanical designs.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Circle",
            "Which fields commonly use circle concepts?",
            "Only history",
            "Only literature",
            "Engineering, astronomy, and computer graphics",
            "Only basic arithmetic",
            QuestionOption.C,
            "Circle geometry is widely used in science, engineering, and technology.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Parabola in Coordinate Geometry

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "What is a parabola?",
            "A curve formed by points equidistant from a focus and directrix",
            "A closed circular shape",
            "A straight line",
            "A polygon with equal sides",
            QuestionOption.A,
            "A parabola is a conic section where every point is equally distant from the focus and directrix.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "The fixed point of a parabola is called:",
            "Directrix",
            "Focus",
            "Vertex",
            "Axis",
            QuestionOption.B,
            "The focus is the fixed point used to define a parabola.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "The fixed line associated with a parabola is called:",
            "Axis of symmetry",
            "Tangent",
            "Directrix",
            "Chord",
            QuestionOption.C,
            "The directrix is the fixed line from which points on a parabola are equally distant from the focus.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "The highest or lowest point of a parabola is called:",
            "Focus",
            "Directrix",
            "Axis",
            "Vertex",
            QuestionOption.D,
            "The vertex is the turning point of a parabola.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "A parabola is a type of:",
            "Conic section",
            "Triangle",
            "Quadrilateral",
            "Circle only",
            QuestionOption.A,
            "Parabola is one of the four major conic sections.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Parabola

        AddQuestion(
            "Equations and Properties of Parabola",
            "Which equation represents a basic parabola opening upward?",
            "y² = 4ax",
            "y = x²",
            "x² + y² = r²",
            "ax + by + c = 0",
            QuestionOption.B,
            "The equation y = x² represents a standard upward-opening parabola.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Parabola",
            "The line that divides a parabola into two equal halves is called:",
            "Focus",
            "Directrix",
            "Axis of symmetry",
            "Tangent",
            QuestionOption.C,
            "The axis of symmetry divides the parabola into two mirror-image halves.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Parabola",
            "In the equation y² = 4ax, the value a represents:",
            "Radius",
            "Slope",
            "Distance from vertex to focus",
            "Diameter",
            QuestionOption.C,
            "The parameter a represents the distance between the vertex and focus.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Parabola",
            "A parabola with equation x² = 4ay opens:",
            "Along the x-axis",
            "Along the y-axis",
            "Only downward",
            "In a circular direction",
            QuestionOption.A,
            "The equation x² = 4ay represents a parabola opening along the y-axis.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Parabola",
            "Which property is true for every parabola?",
            "Every point is equally distant from focus and directrix",
            "It always forms a circle",
            "It has no symmetry",
            "It has four vertices",
            QuestionOption.A,
            "Equal distance from focus and directrix is the defining property of a parabola.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Parabola

        AddQuestion(
            "Applications and Practice of Parabola",
            "Parabolic reflectors are used in:",
            "Satellite dishes and headlights",
            "Flat surfaces",
            "Rectangular designs",
            "Only maps",
            QuestionOption.A,
            "Parabolic shapes reflect signals and light efficiently toward a focus.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Parabola",
            "The path of a projectile under gravity is approximately:",
            "Circular",
            "Parabolic",
            "Linear",
            "Triangular",
            QuestionOption.B,
            "Projectile motion follows a parabolic trajectory when air resistance is ignored.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Parabola",
            "In engineering, parabolas are useful for designing:",
            "Reflectors and optimized structures",
            "Only straight roads",
            "Only square objects",
            "Random patterns",
            QuestionOption.A,
            "Engineers use parabolic curves in antennas, bridges, and optical devices.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Parabola",
            "A satellite communication dish uses a parabola because:",
            "It concentrates signals at the focus",
            "It removes all signals",
            "It creates random waves",
            "It prevents reflection",
            QuestionOption.D,
            "The reflective property of a parabola directs signals toward the focus.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Parabola",
            "Which field commonly applies parabola concepts?",
            "Astronomy and physics",
            "Only literature",
            "Only history",
            "Only basic counting",
            QuestionOption.A,
            "Parabolas are widely used in physics, astronomy, engineering, and technology.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Ellipse in Coordinate Geometry

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "What is an ellipse?",
            "A closed curve where the sum of distances from two fixed points is constant",
            "A straight line with constant slope",
            "A curve with only one focus",
            "A polygon with equal sides",
            QuestionOption.A,
            "An ellipse is defined as a set of points where the sum of distances from two foci remains constant.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "The fixed points used to define an ellipse are called:",
            "Vertices",
            "Foci",
            "Axes",
            "Directrices",
            QuestionOption.B,
            "The two fixed points inside an ellipse are called foci.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "The longest diameter of an ellipse is called:",
            "Minor axis",
            "Radius",
            "Major axis",
            "Directrix",
            QuestionOption.C,
            "The major axis is the longest line segment passing through the centre of an ellipse.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "The shortest diameter of an ellipse is called:",
            "Focus",
            "Major axis",
            "Vertex",
            "Minor axis",
            QuestionOption.D,
            "The minor axis is the shorter diameter perpendicular to the major axis.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "An ellipse is a type of:",
            "Conic section",
            "Triangle",
            "Straight line",
            "Quadrilateral",
            QuestionOption.A,
            "Ellipse is one of the four main conic sections.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Ellipse

        AddQuestion(
            "Equations and Properties of Ellipse",
            "Which equation represents a standard ellipse centred at the origin?",
            "(x²/a²) + (y²/b²) = 1",
            "y = mx + c",
            "x² + y² = r²",
            "ax + by + c = 0",
            QuestionOption.A,
            "The standard ellipse equation uses squared coordinates divided by squared axes lengths.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "In an ellipse equation, a and b represent:",
            "Slopes",
            "Semi-axis lengths",
            "Angles",
            "Coordinates only",
            QuestionOption.B,
            "The values a and b represent the semi-major and semi-minor axis lengths.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "The centre of the ellipse x²/25 + y²/9 = 1 is:",
            "(5,9)",
            "(25,9)",
            "(0,0)",
            "(1,1)",
            QuestionOption.C,
            "Since there are no shifted terms, the ellipse is centred at the origin.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "An ellipse has:",
            "No symmetry",
            "Only one axis",
            "A circular shape always",
            "Two axes of symmetry",
            QuestionOption.D,
            "Every ellipse has symmetry about both its major and minor axes.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "If both axes of an ellipse become equal, the ellipse becomes:",
            "A circle",
            "A parabola",
            "A hyperbola",
            "A line",
            QuestionOption.A,
            "A circle is a special case of an ellipse where both axes are equal.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Ellipse

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Ellipses are used in astronomy to describe:",
            "Planetary orbits",
            "Straight roads",
            "Square structures",
            "Random motion",
            QuestionOption.A,
            "Many planetary orbits are approximately elliptical.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "An elliptical reflector works because:",
            "It blocks all waves",
            "It can direct energy between its foci",
            "It removes the centre point",
            "It creates straight lines",
            QuestionOption.B,
            "A property of ellipses allows signals or sound to travel between the two foci.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Elliptical shapes are commonly used in:",
            "Only arithmetic",
            "Only biology",
            "Architecture and engineering design",
            "Only programming syntax",
            QuestionOption.C,
            "Elliptical designs appear in buildings, mechanical parts, and structures.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Why are ellipse equations important in coordinate geometry?",
            "They connect algebra with geometric curves",
            "They replace all geometric concepts",
            "They only calculate slopes",
            "They cannot model real objects",
            QuestionOption.A,
            "Ellipse equations allow mathematical analysis of curved shapes and real-world systems.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Which field uses ellipse concepts for orbital calculations?",
            "Astronomy",
            "Literature",
            "History",
            "Basic arithmetic",
            QuestionOption.A,
            "Astronomy uses elliptical models to study planetary motion.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Hyperbola in Coordinate Geometry

        AddQuestion(
            "Introduction to Hyperbola in Coordinate Geometry",
            "What is a hyperbola?",
            "A conic section formed by points with a constant difference of distances from two fixed points",
            "A closed circular curve",
            "A straight line",
            "A polygon with equal sides",
            QuestionOption.A,
            "A hyperbola is defined as a set of points where the difference of distances from two foci is constant.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Hyperbola in Coordinate Geometry",
            "The fixed points of a hyperbola are called:",
            "Vertices",
            "Foci",
            "Axes",
            "Directrices",
            QuestionOption.B,
            "The fixed points used to define a hyperbola are called foci.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Hyperbola in Coordinate Geometry",
            "The lines that a hyperbola approaches but never touches are called:",
            "Vertices",
            "Foci",
            "Asymptotes",
            "Axes",
            QuestionOption.C,
            "Asymptotes are lines that guide the shape of a hyperbola as it extends outward.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Hyperbola in Coordinate Geometry",
            "The turning points of a hyperbola are called:",
            "Focus",
            "Directrix",
            "Centre",
            "Vertices",
            QuestionOption.D,
            "The vertices are the points where each branch of a hyperbola reaches its closest point to the centre.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Hyperbola in Coordinate Geometry",
            "A hyperbola is a type of:",
            "Conic section",
            "Triangle",
            "Quadrilateral",
            "Circle only",
            QuestionOption.A,
            "Hyperbola is one of the four main conic sections.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Hyperbola

        AddQuestion(
            "Equations and Properties of Hyperbola",
            "Which equation represents a standard hyperbola centred at the origin?",
            "x²/a² - y²/b² = 1",
            "x² + y² = r²",
            "y = mx + c",
            "ax + by + c = 0",
            QuestionOption.A,
            "The standard equation of a horizontal hyperbola is x²/a² - y²/b² = 1.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Hyperbola",
            "In a hyperbola equation, a represents:",
            "Slope",
            "Distance from centre to vertex",
            "Radius",
            "Area",
            QuestionOption.B,
            "The value a represents the distance from the centre to a vertex.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Hyperbola",
            "The centre of the hyperbola x²/16 - y²/9 = 1 is:",
            "(16,9)",
            "(4,3)",
            "(0,0)",
            "(1,1)",
            QuestionOption.C,
            "Since there are no translated terms, the centre is at the origin.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Hyperbola",
            "A hyperbola has how many branches?",
            "One",
            "Three",
            "Four",
            "Two",
            QuestionOption.D,
            "A standard hyperbola consists of two separate branches.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Hyperbola",
            "Which property helps determine the shape of a hyperbola?",
            "Asymptotes",
            "Only radius",
            "Only circumference",
            "Area formula",
            QuestionOption.A,
            "Asymptotes define the direction and shape of hyperbola branches.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Hyperbola

        AddQuestion(
            "Applications and Practice of Hyperbola",
            "Hyperbolas are used in navigation systems for:",
            "Locating positions using signal differences",
            "Drawing circles only",
            "Calculating areas only",
            "Creating triangles",
            QuestionOption.A,
            "Navigation systems can use hyperbolic curves based on differences in signal arrival times.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Hyperbola",
            "A hyperbolic path can be observed in:",
            "Projectile motion only",
            "Some physics and engineering systems",
            "Only square structures",
            "Only arithmetic problems",
            QuestionOption.B,
            "Hyperbolic models are used in physics, engineering, and signal analysis.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Hyperbola",
            "Hyperbola concepts are applied in:",
            "Only literature",
            "Only history",
            "Engineering and astronomy",
            "Only basic counting",
            QuestionOption.C,
            "Engineering and astronomy use hyperbolic models for analysis and design.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Hyperbola",
            "Why are hyperbola equations important in coordinate geometry?",
            "They connect algebra with complex geometric curves",
            "They remove the need for graphs",
            "They only describe circles",
            "They cannot model real systems",
            QuestionOption.A,
            "Hyperbola equations allow mathematical analysis of important curved structures.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Hyperbola",
            "Which technology uses hyperbolic principles for positioning?",
            "GPS and navigation systems",
            "Text editors",
            "Image filters only",
            "Simple calculators",
            QuestionOption.A,
            "Navigation technologies use hyperbolic relationships for accurate positioning.",
            DifficultyLevel.Advance,
            5);
        // Introduction to Conic Sections

        AddQuestion(
            "Introduction to Conic Sections",
            "What are conic sections?",
            "Curves obtained by intersecting a cone with a plane",
            "Types of polygons",
            "Straight lines only",
            "Arithmetic formulas",
            QuestionOption.A,
            "Conic sections are curves formed when a plane intersects a double cone.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Conic Sections",
            "Which of the following is a conic section?",
            "Square",
            "Ellipse",
            "Triangle",
            "Rectangle",
            QuestionOption.B,
            "An ellipse is one of the four main conic sections.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Conic Sections",
            "The four main types of conic sections are:",
            "Triangles, squares, circles, rectangles",
            "Lines, angles, points, planes",
            "Circle, parabola, ellipse, and hyperbola",
            "Only circles and lines",
            QuestionOption.C,
            "The four major conic sections are circles, parabolas, ellipses, and hyperbolas.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Conic Sections",
            "Which conic section has a constant distance from a centre point?",
            "Parabola",
            "Hyperbola",
            "Ellipse",
            "Circle",
            QuestionOption.D,
            "A circle is defined as all points at a fixed distance from the centre.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Conic Sections",
            "Conic sections are mainly studied in:",
            "Coordinate geometry",
            "Basic arithmetic",
            "Number theory only",
            "Statistics only",
            QuestionOption.A,
            "Coordinate geometry uses equations to represent and analyse conic sections.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Conic Sections

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which equation represents a circle centred at the origin?",
            "x² + y² = r²",
            "y = mx + c",
            "x²/a² - y²/b² = 1",
            "y² = 4ax",
            QuestionOption.A,
            "The equation x² + y² = r² represents a circle with centre at the origin.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which conic section is represented by y = x²?",
            "Circle",
            "Parabola",
            "Ellipse",
            "Hyperbola",
            QuestionOption.B,
            "The equation y = x² represents a standard upward-opening parabola.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "The equation x²/a² + y²/b² = 1 represents:",
            "Hyperbola",
            "Parabola",
            "Ellipse",
            "Straight line",
            QuestionOption.C,
            "The standard ellipse equation contains the sum of two squared terms equal to one.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "The equation x²/a² - y²/b² = 1 represents:",
            "Circle",
            "Ellipse",
            "Parabola",
            "Hyperbola",
            QuestionOption.D,
            "A difference between squared terms represents a standard hyperbola.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which property helps classify different conic sections?",
            "Their equations and geometric characteristics",
            "Only their colours",
            "Only their sizes",
            "Only their positions",
            QuestionOption.A,
            "Conic sections are classified using their equations and geometric properties.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Conic Sections

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Conic sections are used in astronomy for:",
            "Studying planetary orbits",
            "Writing documents",
            "Counting numbers",
            "Creating tables",
            QuestionOption.A,
            "Elliptical and hyperbolic paths are important in astronomy.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Parabolic reflectors are commonly used in:",
            "Satellite dishes and antennas",
            "Flat surfaces",
            "Random structures",
            "Only books",
            QuestionOption.B,
            "Parabolic reflectors focus signals and waves efficiently.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Which field uses conic sections for modelling real-world structures?",
            "Only history",
            "Only literature",
            "Engineering and physics",
            "Only basic calculation",
            QuestionOption.C,
            "Engineering and physics use conic sections for modelling curves and motion.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Why are conic sections important in mathematics?",
            "They connect algebra with geometric shapes and real applications",
            "They replace all mathematical topics",
            "They only describe straight lines",
            "They cannot be used practically",
            QuestionOption.A,
            "Conic sections provide mathematical models for many scientific and engineering systems.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Which technology uses conic section principles?",
            "Optics, navigation, and engineering systems",
            "Only calculators",
            "Only text processing",
            "Only simple arithmetic",
            QuestionOption.A,
            "Many technologies rely on conic sections for design and analysis.",
            DifficultyLevel.Advance,
            5);


        // PQ. 3
        // ==========================================================
        // Introduction to Cartesian Plane
        // ==========================================================

        AddQuestion(
            "Introduction to Cartesian Plane",
            "What is the Cartesian plane?",
            "A mathematical equation",
            "A two-dimensional coordinate system used to locate points",
            "A type of triangle",
            "A collection of numbers",
            QuestionOption.B,
            "The Cartesian plane is a two-dimensional coordinate system formed by the x-axis and y-axis, used to locate points.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "Which axis runs horizontally on the Cartesian plane?",
            "y-axis",
            "z-axis",
            "x-axis",
            "Origin axis",
            QuestionOption.C,
            "The x-axis is the horizontal axis, while the y-axis is vertical.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "What is the point where the x-axis and y-axis intersect called?",
            "Quadrant",
            "Midpoint",
            "Origin",
            "Vertex",
            QuestionOption.C,
            "The origin is the point (0,0) where both coordinate axes intersect.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "Which ordered pair represents the origin?",
            "(1,1)",
            "(0,1)",
            "(1,0)",
            "(0,0)",
            QuestionOption.D,
            "The origin has both x-coordinate and y-coordinate equal to zero.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "Why is the Cartesian plane important in mathematics?",
            "It is only used to draw circles.",
            "It helps represent and analyze the positions of points using coordinates.",
            "It replaces algebra completely.",
            "It is only used in geometry.",
            QuestionOption.B,
            "The Cartesian plane provides a way to locate points and visualize mathematical relationships.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Understanding Coordinates and Quadrants
        // ==========================================================

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "In the ordered pair (5, -2), what is the x-coordinate?",
            "5",
            "-2",
            "3",
            "0",
            QuestionOption.A,
            "The first number in an ordered pair represents the x-coordinate.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "A point with coordinates (4, 3) lies in which quadrant?",
            "Quadrant I",
            "Quadrant II",
            "Quadrant III",
            "Quadrant IV",
            QuestionOption.A,
            "Both coordinates are positive, so the point lies in Quadrant I.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "A point with coordinates (-5, 2) lies in which quadrant?",
            "Quadrant I",
            "Quadrant II",
            "Quadrant III",
            "Quadrant IV",
            QuestionOption.B,
            "A negative x-coordinate and positive y-coordinate place the point in Quadrant II.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "Which point lies in Quadrant III?",
            "(3, -2)",
            "(-4, 5)",
            "(-2, -6)",
            "(5, 4)",
            QuestionOption.C,
            "Quadrant III contains points where both x and y coordinates are negative.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "What is the correct order when writing coordinates?",
            "(y, x)",
            "(x + y)",
            "(x, y)",
            "(y - x)",
            QuestionOption.C,
            "Coordinates are always written in the form (x, y), where x comes first followed by y.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Cartesian Plane
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "Which of the following uses the Cartesian plane in real life?",
            "Maps and GPS systems",
            "Cooking recipes",
            "Alphabetical sorting",
            "Calendar dates",
            QuestionOption.A,
            "Maps and GPS use coordinate systems to identify exact locations.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "A treasure is located at (6, -4). Which direction from the origin must you move first?",
            "6 units left",
            "6 units right",
            "4 units up",
            "4 units left",
            QuestionOption.B,
            "Move 6 units to the right along the x-axis, then 4 units down along the y-axis.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "A point lies on the y-axis. Which statement is true?",
            "Its y-coordinate is always 0.",
            "Its x-coordinate is always 0.",
            "Both coordinates are positive.",
            "Its x-coordinate equals its y-coordinate.",
            QuestionOption.B,
            "Every point on the y-axis has an x-coordinate of 0.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "Which point lies on the x-axis?",
            "(0, 5)",
            "(3, 0)",
            "(2, 2)",
            "(-1, 4)",
            QuestionOption.B,
            "Points on the x-axis always have a y-coordinate of 0.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "Why is the Cartesian plane widely used in mathematics, science, and engineering?",
            "It allows precise representation of positions, graphs, and relationships between variables.",
            "It is only useful for drawing shapes.",
            "It replaces the need for equations.",
            "It can only represent whole numbers.",
            QuestionOption.A,
            "The Cartesian plane is essential for graphing functions, locating positions, and modelling real-world situations.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Distance Formula
        // ==========================================================

        AddQuestion(
            "Introduction to Distance Formula",
            "What is the primary purpose of the distance formula?",
            "To find the midpoint of two points",
            "To calculate the distance between two points on a coordinate plane",
            "To find the slope of a line",
            "To determine the area of a triangle",
            QuestionOption.B,
            "The distance formula is used to calculate the straight-line distance between two points on a coordinate plane.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Distance Formula",
            "The distance formula is derived from which mathematical theorem?",
            "Fundamental Theorem of Algebra",
            "Pythagorean Theorem",
            "Binomial Theorem",
            "Euclid's Division Lemma",
            QuestionOption.B,
            "The distance formula is derived using the Pythagorean Theorem.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Distance Formula",
            "Which expression correctly represents the distance between two points (x₁, y₁) and (x₂, y₂)?",
            "√((x₂ - x₁)² + (y₂ - y₁)²)",
            "(x₂ - x₁) + (y₂ - y₁)",
            "(x₁ + x₂) / 2",
            "(y₂ - y₁) / (x₂ - x₁)",
            QuestionOption.A,
            "The distance formula is √((x₂ - x₁)² + (y₂ - y₁)²).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Distance Formula",
            "What is the distance between the points (2, 3) and (2, 8)?",
            "3",
            "5",
            "6",
            "8",
            QuestionOption.B,
            "Since the x-coordinates are the same, the distance is the difference between the y-coordinates: 8 - 3 = 5.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Distance Formula",
            "Why is the distance formula important in coordinate geometry?",
            "It helps calculate exact distances between points.",
            "It only finds the midpoint of a line segment.",
            "It is only used for horizontal lines.",
            "It replaces the need for coordinates.",
            QuestionOption.A,
            "The distance formula provides an accurate way to measure the distance between any two points on a coordinate plane.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Problems Using Distance Formula
        // ==========================================================

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "What is the distance between the points (1, 1) and (4, 5)?",
            "4",
            "5",
            "6",
            "7",
            QuestionOption.B,
            "Distance = √((4-1)² + (5-1)²) = √(9 + 16) = √25 = 5.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "Find the distance between the points (-2, 3) and (-2, 9).",
            "4",
            "5",
            "6",
            "7",
            QuestionOption.C,
            "The x-coordinates are equal, so the distance is |9 - 3| = 6.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "What is the distance between (0, 0) and (6, 8)?",
            "8",
            "9",
            "10",
            "12",
            QuestionOption.C,
            "Distance = √(6² + 8²) = √100 = 10.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "The distance between two points is always:",
            "Negative",
            "Positive or zero",
            "Less than 1",
            "An integer",
            QuestionOption.B,
            "Distance represents length, which cannot be negative.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "Which situation requires the use of the distance formula?",
            "Finding the straight-line distance between two cities on a coordinate map",
            "Finding the average of two numbers",
            "Adding two fractions",
            "Multiplying matrices",
            QuestionOption.A,
            "The distance formula is used whenever the straight-line distance between two coordinate points is required.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Distance Formula
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "Which profession commonly uses the distance formula for mapping and measurements?",
            "Cartographers",
            "Chefs",
            "Musicians",
            "Poets",
            QuestionOption.A,
            "Cartographers use coordinate systems and distance calculations when creating maps.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "The distance formula helps determine the:",
            "Straight-line distance between two locations",
            "Temperature of an object",
            "Colour of a graph",
            "Weight of a point",
            QuestionOption.A,
            "It calculates the shortest straight-line distance between two coordinate points.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "In computer graphics, the distance formula is commonly used to:",
            "Measure the distance between objects on the screen",
            "Change font styles",
            "Store files",
            "Connect to the internet",
            QuestionOption.A,
            "Computer graphics frequently use distance calculations for rendering, collision detection, and animation.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "If two points have the same coordinates, what is the distance between them?",
            "0",
            "1",
            "Undefined",
            "Cannot be determined",
            QuestionOption.A,
            "The distance between a point and itself is always zero.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "Why is the distance formula widely used in science, engineering, and navigation?",
            "It provides an accurate method for measuring distances between coordinate points.",
            "It only works with horizontal lines.",
            "It replaces the need for maps.",
            "It is only useful in classrooms.",
            QuestionOption.A,
            "The distance formula is fundamental for solving real-world measurement problems involving coordinates.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Midpoint Formula
        // ==========================================================

        AddQuestion(
            "Introduction to Midpoint Formula",
            "What is the purpose of the midpoint formula?",
            "To find the distance between two points",
            "To find the point exactly halfway between two points",
            "To calculate the slope of a line",
            "To determine the area of a rectangle",
            QuestionOption.B,
            "The midpoint formula is used to find the point that lies exactly halfway between two points on a line segment.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "The midpoint formula finds the average of which values?",
            "Only the x-coordinates",
            "Only the y-coordinates",
            "The x-coordinates and y-coordinates separately",
            "The distances between the points",
            QuestionOption.C,
            "The midpoint is found by averaging the x-coordinates and the y-coordinates separately.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "Which expression correctly represents the midpoint of two points (x₁, y₁) and (x₂, y₂)?",
            "((x₁+x₂)/2, (y₁+y₂)/2)",
            "(x₂-x₁, y₂-y₁)",
            "((x₂-x₁)/2, (y₂-y₁)/2)",
            "(x₁+x₂, y₁+y₂)",
            QuestionOption.A,
            "The midpoint formula averages the x-coordinates and the y-coordinates independently.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "What is the midpoint of the points (2, 4) and (6, 8)?",
            "(4, 6)",
            "(8, 12)",
            "(2, 2)",
            "(5, 6)",
            QuestionOption.A,
            "The midpoint is ((2+6)/2, (4+8)/2) = (4, 6).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "Why is the midpoint formula useful in coordinate geometry?",
            "It finds the exact center between two points.",
            "It calculates the length of a line segment.",
            "It determines the slope of a line.",
            "It only works for horizontal lines.",
            QuestionOption.A,
            "The midpoint formula identifies the exact center point of a line segment.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Problems Using Midpoint Formula
        // ==========================================================

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "Find the midpoint of the points (0, 0) and (4, 6).",
            "(2, 3)",
            "(4, 3)",
            "(2, 6)",
            "(0, 3)",
            QuestionOption.A,
            "Midpoint = ((0+4)/2, (0+6)/2) = (2, 3).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "What is the midpoint of (-2, 4) and (6, 8)?",
            "(2, 6)",
            "(4, 6)",
            "(2, 4)",
            "(6, 8)",
            QuestionOption.A,
            "Midpoint = ((-2+6)/2, (4+8)/2) = (2, 6).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "What is the midpoint of (3, -1) and (7, 5)?",
            "(5, 2)",
            "(4, 2)",
            "(5, 3)",
            "(10, 4)",
            QuestionOption.A,
            "Midpoint = ((3+7)/2, (-1+5)/2) = (5, 2).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "If the midpoint of two points is (0, 0), which statement could be true?",
            "The points are (2, 2) and (-2, -2).",
            "The points are (1, 1) and (2, 2).",
            "The points are (0, 3) and (0, 4).",
            "The points are (5, 0) and (6, 0).",
            QuestionOption.A,
            "The average of the x-coordinates and y-coordinates is 0 for the points (2,2) and (-2,-2).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "When solving midpoint problems, what mathematical operation is always performed?",
            "Multiplication",
            "Division by 2 after adding corresponding coordinates",
            "Subtraction only",
            "Squaring each coordinate",
            QuestionOption.B,
            "The midpoint is found by adding corresponding coordinates and dividing each sum by 2.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Midpoint Formula
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "The midpoint formula can be used to:",
            "Find the center point between two locations",
            "Calculate the area of a circle",
            "Multiply two matrices",
            "Find the perimeter of a triangle",
            QuestionOption.A,
            "The midpoint formula helps locate the point exactly halfway between two positions.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "Architects and engineers often use the midpoint formula to:",
            "Determine the center of structures and designs",
            "Measure temperature",
            "Calculate percentages",
            "Convert units",
            QuestionOption.A,
            "Finding exact center points is important when designing balanced structures.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "In computer graphics, the midpoint formula is useful for:",
            "Finding the center between two points on a screen",
            "Compressing files",
            "Connecting to networks",
            "Increasing screen brightness",
            QuestionOption.A,
            "Computer graphics use midpoint calculations for drawing and positioning objects.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "If two endpoints of a road are known, the midpoint represents:",
            "The halfway point between the endpoints",
            "The total length of the road",
            "The slope of the road",
            "The highest point on the road",
            QuestionOption.A,
            "The midpoint identifies the location exactly halfway between the two endpoints.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "Why is the midpoint formula important in mathematics and real-world applications?",
            "It accurately identifies the center point between two coordinates for analysis and design.",
            "It only works for horizontal lines.",
            "It replaces the distance formula.",
            "It is only useful in classroom exercises.",
            QuestionOption.A,
            "The midpoint formula is widely used in geometry, engineering, mapping, computer graphics, and construction to determine central positions.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Section Formula
        // ==========================================================

        AddQuestion(
            "Introduction to Section Formula",
            "What is the purpose of the section formula?",
            "To calculate the distance between two points",
            "To find a point that divides a line segment in a given ratio",
            "To determine the slope of a line",
            "To find the midpoint of a circle",
            QuestionOption.B,
            "The section formula is used to determine the coordinates of a point dividing a line segment in a specified ratio.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Section Formula",
            "The section formula is mainly used in:",
            "Coordinate geometry",
            "Probability",
            "Statistics",
            "Trigonometry",
            QuestionOption.A,
            "The section formula is an important concept in coordinate geometry.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Section Formula",
            "If a point divides a line segment into two equal parts, it is called the:",
            "Origin",
            "Centroid",
            "Midpoint",
            "Vertex",
            QuestionOption.C,
            "A point dividing a line segment into two equal parts is the midpoint.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Section Formula",
            "A point dividing a line segment in the ratio 2:3 lies:",
            "Exactly at the midpoint",
            "Closer to one endpoint than the other",
            "Outside the line segment",
            "At the origin",
            QuestionOption.B,
            "A ratio other than 1:1 places the point closer to one endpoint.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Section Formula",
            "Why is the section formula useful?",
            "It helps locate points dividing line segments accurately.",
            "It only calculates line lengths.",
            "It only works for horizontal lines.",
            "It replaces the midpoint formula.",
            QuestionOption.A,
            "The section formula accurately determines points dividing line segments in specified ratios.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Problems Using Section Formula
        // ==========================================================

        AddQuestion(
            "Solving Problems Using Section Formula",
            "The midpoint formula is a special case of the section formula when the ratio is:",
            "1 : 1",
            "1 : 2",
            "2 : 3",
            "3 : 1",
            QuestionOption.A,
            "When the ratio is 1:1, the section formula gives the midpoint.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "A point divides a line segment internally in the ratio 3:2. Which ratio is used in the section formula?",
            "3:2",
            "2:3",
            "1:1",
            "5:1",
            QuestionOption.A,
            "The given internal ratio is used directly in the section formula.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "Which coordinate values are required to apply the section formula?",
            "Only the x-coordinates",
            "Only the y-coordinates",
            "Coordinates of both endpoints",
            "Only the midpoint",
            QuestionOption.C,
            "The coordinates of both endpoints are needed to calculate the required point.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "If a point divides a line segment internally in the ratio 1:1, the result is:",
            "The origin",
            "The midpoint",
            "The distance",
            "The slope",
            QuestionOption.B,
            "A ratio of 1:1 always gives the midpoint of the segment.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "The section formula is most useful when:",
            "A point divides a line segment in a known ratio",
            "Only the length of a line is required",
            "Finding the area of a rectangle",
            "Calculating percentages",
            QuestionOption.A,
            "The section formula is specifically designed to locate dividing points on a line segment.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Section Formula
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Section Formula",
            "The section formula is commonly applied in:",
            "Coordinate geometry",
            "Cooking recipes",
            "Grammar exercises",
            "Music notation",
            QuestionOption.A,
            "Coordinate geometry frequently uses the section formula to locate points.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "Surveyors may use the section formula to:",
            "Locate points dividing measured land into specific ratios",
            "Measure temperature",
            "Calculate electricity usage",
            "Find rainfall",
            QuestionOption.A,
            "Surveying often requires dividing measured distances accurately.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "Computer graphics use the section formula to:",
            "Position objects proportionally between two points",
            "Increase screen brightness",
            "Store files",
            "Play animations",
            QuestionOption.A,
            "Graphics software often calculates intermediate positions using coordinate geometry.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "The section formula helps engineers by:",
            "Finding precise positions along structures and designs",
            "Calculating sound volume",
            "Measuring humidity",
            "Finding internet speed",
            QuestionOption.A,
            "Engineers use coordinate geometry to locate precise design points.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "Why is the section formula important in mathematics and engineering?",
            "It accurately determines points that divide line segments in specified ratios.",
            "It only works for vertical lines.",
            "It replaces the distance formula.",
            "It is only useful in classroom examples.",
            QuestionOption.A,
            "The section formula has practical applications in geometry, engineering, mapping, construction, and computer graphics where proportional division is required.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Straight Line
        // ==========================================================

        AddQuestion(
            "Introduction to Straight Line",
            "What is a straight line?",
            "A curve with no fixed direction",
            "The shortest distance between two points",
            "A closed geometric shape",
            "A circle passing through two points",
            QuestionOption.B,
            "A straight line represents the shortest distance between two points and extends infinitely in both directions.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Straight Line",
            "Which equation is in the slope-intercept form of a straight line?",
            "x² + y² = 1",
            "y = mx + c",
            "ax² + bx + c = 0",
            "x + y² = 5",
            QuestionOption.B,
            "The equation y = mx + c represents a straight line where m is the slope and c is the y-intercept.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Straight Line",
            "What does the slope (m) of a straight line represent?",
            "Its area",
            "Its length",
            "Its steepness and direction",
            "Its midpoint",
            QuestionOption.C,
            "The slope describes how steep a line is and whether it rises or falls.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Straight Line",
            "What is the y-intercept of the line y = 3x + 4?",
            "3",
            "4",
            "7",
            "0",
            QuestionOption.B,
            "The y-intercept is the value of y when x = 0, which is 4.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Straight Line",
            "Why are straight lines important in mathematics?",
            "They help model linear relationships between quantities.",
            "They are only used to draw graphs.",
            "They can only represent horizontal lines.",
            "They replace all other geometric figures.",
            QuestionOption.A,
            "Straight lines are fundamental for representing linear relationships in mathematics and science.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Straight Lines
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "What is the slope of the line y = 5x + 2?",
            "2",
            "5",
            "7",
            "-5",
            QuestionOption.B,
            "In the equation y = mx + c, the slope is the coefficient of x.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "A horizontal line has a slope of:",
            "1",
            "0",
            "Undefined",
            "-1",
            QuestionOption.B,
            "A horizontal line has no vertical change, so its slope is 0.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "A vertical line has a slope that is:",
            "0",
            "1",
            "Undefined",
            "-1",
            QuestionOption.C,
            "Since the horizontal change is zero, the slope of a vertical line is undefined.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "Two lines with the same slope are:",
            "Perpendicular",
            "Parallel",
            "Intersecting at the origin",
            "Always identical",
            QuestionOption.B,
            "Lines having the same slope are parallel if they have different intercepts.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "Which point lies on the line y = 2x + 1?",
            "(1, 2)",
            "(2, 4)",
            "(2, 5)",
            "(3, 8)",
            QuestionOption.C,
            "Substituting x = 2 gives y = 2(2) + 1 = 5, so (2,5) lies on the line.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Straight Lines
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "Straight line graphs are commonly used to represent:",
            "Linear relationships between variables",
            "Circular motion only",
            "Random shapes",
            "Three-dimensional objects",
            QuestionOption.A,
            "Straight lines are used to represent linear relationships between two quantities.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "Which profession commonly uses straight line graphs for data analysis?",
            "Engineers",
            "Painters",
            "Musicians",
            "Photographers",
            QuestionOption.A,
            "Engineers frequently use straight-line graphs to analyze measurements and trends.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "In economics, a straight line graph can represent:",
            "The relationship between cost and quantity",
            "The phases of the moon",
            "The colour of products",
            "The shape of planets",
            QuestionOption.A,
            "Many economic relationships, such as fixed-rate costs, can be represented using straight lines.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "A positive slope indicates that the line:",
            "Falls from left to right",
            "Rises from left to right",
            "Is horizontal",
            "Is vertical",
            QuestionOption.B,
            "A positive slope means y increases as x increases.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "Why are straight lines important in science and engineering?",
            "They help model, analyze, and predict relationships between measurable quantities.",
            "They are only useful in geometry classes.",
            "They replace all mathematical formulas.",
            "They are only used for drawing graphs.",
            QuestionOption.A,
            "Straight lines are widely used to model physical laws, engineering designs, and data trends.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Pair of Straight Lines
        // ==========================================================

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "What is meant by a pair of straight lines?",
            "A single line passing through two points",
            "Two straight lines represented together by one equation",
            "Two parallel curves",
            "A line segment and a ray",
            QuestionOption.B,
            "A pair of straight lines consists of two straight lines that can be represented together by a single equation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "A pair of straight lines may be:",
            "Only parallel",
            "Only perpendicular",
            "Intersecting or parallel",
            "Always coincident",
            QuestionOption.C,
            "A pair of straight lines can intersect, be parallel, or even coincide depending on the equation.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "Where do two intersecting straight lines meet?",
            "At exactly one point",
            "At two points",
            "They never meet",
            "At infinitely many points",
            QuestionOption.A,
            "Intersecting lines meet at one unique point.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "If two straight lines never meet, they are called:",
            "Perpendicular lines",
            "Intersecting lines",
            "Parallel lines",
            "Coincident lines",
            QuestionOption.C,
            "Parallel lines remain the same distance apart and never intersect.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "Why are pairs of straight lines important in coordinate geometry?",
            "They help analyze relationships between two lines on a plane.",
            "They are only used for drawing graphs.",
            "They replace quadratic equations.",
            "They are only useful in statistics.",
            QuestionOption.A,
            "Studying pairs of straight lines helps understand intersections, angles, and geometric relationships.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Pair of Straight Lines
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "Two lines having the same slope are:",
            "Perpendicular",
            "Parallel",
            "Intersecting",
            "Coincident with the x-axis",
            QuestionOption.B,
            "Lines with equal slopes are parallel if they have different intercepts.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "Perpendicular lines intersect at an angle of:",
            "45°",
            "60°",
            "90°",
            "180°",
            QuestionOption.C,
            "Perpendicular lines always meet at a right angle of 90°.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "If two lines intersect, they have:",
            "Exactly one common point",
            "No common points",
            "Infinitely many common points",
            "Exactly two common points",
            QuestionOption.A,
            "Intersecting lines always meet at one point.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "Coincident lines are lines that:",
            "Never meet",
            "Meet at one point",
            "Lie exactly on top of each other",
            "Are always perpendicular",
            QuestionOption.C,
            "Coincident lines overlap completely and share every point.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "Which property is true for parallel lines?",
            "They intersect at one point.",
            "They have equal slopes.",
            "They always pass through the origin.",
            "They form a right angle.",
            QuestionOption.B,
            "Parallel lines have the same slope and never intersect.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Pair of Straight Lines
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Pairs of straight lines are commonly used in:",
            "Coordinate geometry",
            "Cooking",
            "Poetry",
            "Music theory",
            QuestionOption.A,
            "Coordinate geometry studies the relationships between straight lines on a plane.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Road intersections can be modeled using:",
            "Parallel circles",
            "Intersecting straight lines",
            "Random curves",
            "Triangles only",
            QuestionOption.B,
            "Roads crossing each other can be represented by intersecting straight lines.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Railway tracks are often represented by which type of pair of lines?",
            "Perpendicular lines",
            "Parallel lines",
            "Coincident lines",
            "Curved lines",
            QuestionOption.B,
            "Railway tracks remain at a constant distance from each other and are modeled as parallel lines.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Architects use pairs of straight lines mainly to:",
            "Design walls, beams, and layouts accurately",
            "Measure rainfall",
            "Predict earthquakes",
            "Calculate probabilities",
            QuestionOption.A,
            "Buildings and structures are designed using geometric relationships between straight lines.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Why is the study of pairs of straight lines important?",
            "It helps solve geometric, engineering, and graphical problems involving relationships between lines.",
            "It is only useful for drawing graphs.",
            "It replaces the distance formula.",
            "It is only used in classroom activities.",
            QuestionOption.A,
            "Understanding how two lines relate helps solve many real-world problems in engineering, architecture, mapping, and mathematics.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Circle in Coordinate Geometry
        // ==========================================================

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "What is a circle in coordinate geometry?",
            "A polygon with equal sides",
            "A set of points equidistant from a fixed point",
            "A straight line joining two points",
            "A curved line with two centers",
            QuestionOption.B,
            "A circle is the set of all points that are at the same distance (radius) from a fixed point called the center.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "What is the fixed point of a circle called?",
            "Radius",
            "Diameter",
            "Center",
            "Chord",
            QuestionOption.C,
            "Every point on a circle is equally distant from its center.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "What is the distance from the center of a circle to any point on the circle called?",
            "Diameter",
            "Radius",
            "Chord",
            "Circumference",
            QuestionOption.B,
            "The radius is the constant distance from the center to any point on the circle.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "Which of the following is the standard equation of a circle with center (h, k) and radius r?",
            "x² + y² = r",
            "(x - h)² + (y - k)² = r²",
            "y = mx + c",
            "ax² + bx + c = 0",
            QuestionOption.B,
            "The standard equation of a circle is (x - h)² + (y - k)² = r².",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "Why is the equation of a circle important?",
            "It helps locate and analyze circles on the coordinate plane.",
            "It is only used to calculate perimeter.",
            "It replaces all geometric formulas.",
            "It is only useful for drawing.",
            QuestionOption.A,
            "The equation allows us to determine the center, radius, and other properties of a circle.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Circle
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Circle",
            "What is the center of the circle x² + y² = 25?",
            "(5, 5)",
            "(0, 0)",
            "(25, 0)",
            "(0, 25)",
            QuestionOption.B,
            "The equation x² + y² = 25 represents a circle centered at the origin.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Circle",
            "What is the radius of the circle x² + y² = 49?",
            "49",
            "24.5",
            "7",
            "14",
            QuestionOption.C,
            "Since r² = 49, the radius is 7.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Circle",
            "The center of the circle (x - 3)² + (y + 2)² = 16 is:",
            "(3, -2)",
            "(-3, 2)",
            "(3, 2)",
            "(-3, -2)",
            QuestionOption.A,
            "The center is (h, k), so here it is (3, -2).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Circle",
            "The radius of the circle (x - 1)² + (y - 4)² = 36 is:",
            "3",
            "6",
            "12",
            "36",
            QuestionOption.B,
            "Since r² = 36, the radius is 6.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Circle",
            "Which property is true for every circle?",
            "All radii are equal.",
            "All diameters are different.",
            "Every chord passes through the center.",
            "A circle has four sides.",
            QuestionOption.A,
            "Every radius of a circle has the same length.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Circle
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Circle",
            "Circles are commonly used in:",
            "Wheel design",
            "Writing essays",
            "Sorting numbers",
            "Reading books",
            QuestionOption.A,
            "Wheels, gears, and many mechanical components are circular in shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Circle",
            "GPS coverage around a fixed location is often represented using:",
            "A triangle",
            "A square",
            "A circle",
            "A rectangle",
            QuestionOption.C,
            "A fixed distance from a central point forms a circular region.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Circle",
            "In engineering, circle equations help in:",
            "Designing circular structures and machine parts",
            "Writing software documentation",
            "Sorting databases",
            "Managing emails",
            QuestionOption.A,
            "Many engineering designs involve circular objects and require circle equations.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Circle",
            "Which real-world object is best represented by a circle in coordinate geometry?",
            "A bicycle wheel",
            "A notebook",
            "A television",
            "A ruler",
            QuestionOption.A,
            "A bicycle wheel closely resembles a perfect circle.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Circle",
            "Why is the study of circles important in mathematics and science?",
            "It helps model circular objects, motion, and geometric relationships accurately.",
            "It only helps in drawing diagrams.",
            "It replaces straight-line equations.",
            "It is only useful for examinations.",
            QuestionOption.A,
            "Circle equations are widely used in physics, engineering, architecture, navigation, and computer graphics.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Parabola in Coordinate Geometry
        // ==========================================================

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "What is a parabola?",
            "A closed circular curve",
            "A set of points equidistant from a fixed point and a fixed line",
            "A straight line",
            "A polygon with four sides",
            QuestionOption.B,
            "A parabola is the set of all points that are equidistant from a fixed point (focus) and a fixed line (directrix).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "What is the fixed point of a parabola called?",
            "Vertex",
            "Center",
            "Focus",
            "Radius",
            QuestionOption.C,
            "The fixed point used to define a parabola is called the focus.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "What is the fixed line associated with a parabola called?",
            "Axis",
            "Diameter",
            "Directrix",
            "Chord",
            QuestionOption.C,
            "The directrix is the fixed line used in the definition of a parabola.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "The point where a parabola changes direction is called the:",
            "Focus",
            "Vertex",
            "Origin",
            "Intercept",
            QuestionOption.B,
            "The vertex is the turning point of a parabola.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "Why are parabolas important in coordinate geometry?",
            "They help model curved paths and reflective surfaces.",
            "They only represent circles.",
            "They replace straight lines.",
            "They are only used for classroom exercises.",
            QuestionOption.A,
            "Parabolas are widely used to model projectile motion, satellite dishes, and reflective surfaces.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Parabola
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Parabola",
            "Which of the following is the standard equation of a parabola opening to the right?",
            "x² = 4ay",
            "y² = 4ax",
            "x² + y² = r²",
            "y = mx + c",
            QuestionOption.B,
            "The standard equation of a parabola opening to the right is y² = 4ax.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Parabola",
            "The graph of x² = 4ay opens:",
            "Left and right",
            "Upward or downward",
            "In all directions",
            "As a straight line",
            QuestionOption.B,
            "The equation x² = 4ay represents a parabola opening upward if a > 0 and downward if a < 0.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Parabola",
            "Every parabola has:",
            "One focus and one directrix",
            "Two centers",
            "Two radii",
            "Four vertices",
            QuestionOption.A,
            "A parabola is uniquely defined by one focus and one directrix.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Parabola",
            "The axis of symmetry of a parabola:",
            "Divides the parabola into two equal halves",
            "Is always horizontal",
            "Is always vertical",
            "Does not pass through the vertex",
            QuestionOption.A,
            "The axis of symmetry passes through the vertex and divides the parabola into two mirror-image halves.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Parabola",
            "Which statement is true for every parabola?",
            "It has exactly one vertex.",
            "It has two centers.",
            "It is a closed curve.",
            "It always forms a circle.",
            QuestionOption.A,
            "Every parabola has exactly one vertex, which is its turning point.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Parabola
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Parabola",
            "The path of a ball thrown into the air is approximately:",
            "A straight line",
            "A circle",
            "A parabola",
            "A rectangle",
            QuestionOption.C,
            "Ignoring air resistance, projectile motion follows a parabolic path.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Parabola",
            "Satellite dishes are designed using the shape of a:",
            "Circle",
            "Triangle",
            "Parabola",
            "Rectangle",
            QuestionOption.C,
            "Parabolic reflectors focus incoming signals at a single point called the focus.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Parabola",
            "Car headlights commonly use parabolic reflectors because they:",
            "Scatter light in every direction",
            "Focus light into a strong beam",
            "Reduce battery usage",
            "Make the bulb brighter",
            QuestionOption.B,
            "A parabolic reflector directs light rays into a nearly parallel beam.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Parabola",
            "Parabolas are commonly used in which field?",
            "Engineering and physics",
            "Cooking",
            "Music composition",
            "Language translation",
            QuestionOption.A,
            "Parabolas are widely used in engineering, architecture, physics, and communication systems.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Parabola",
            "Why are parabolas important in science and technology?",
            "They accurately model curved motion and reflective surfaces used in many real-world applications.",
            "They only help draw graphs.",
            "They replace circle equations.",
            "They are only useful in mathematics classrooms.",
            QuestionOption.A,
            "Parabolas are fundamental in projectile motion, satellite communication, optics, and engineering design.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Ellipse in Coordinate Geometry
        // ==========================================================

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "What is an ellipse?",
            "A closed curve where the sum of the distances from any point to two fixed points is constant",
            "A circle with two centers",
            "A straight line",
            "A polygon with four sides",
            QuestionOption.A,
            "An ellipse is the set of all points for which the sum of the distances from two fixed points (foci) remains constant.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "The two fixed points of an ellipse are called:",
            "Vertices",
            "Centers",
            "Foci",
            "Axes",
            QuestionOption.C,
            "The fixed points used to define an ellipse are called the foci.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "Which axis of an ellipse is the longest?",
            "Minor axis",
            "Major axis",
            "Vertical axis",
            "Horizontal axis",
            QuestionOption.B,
            "The major axis is the longest diameter of an ellipse.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "What is the center of an ellipse?",
            "The midpoint of its major and minor axes",
            "One of its foci",
            "The highest point",
            "The point where it touches the x-axis",
            QuestionOption.A,
            "The center is the midpoint where the major and minor axes intersect.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "Why are ellipses important in coordinate geometry?",
            "They help model many natural and engineered shapes.",
            "They only represent circles.",
            "They replace straight lines.",
            "They are only used in examinations.",
            QuestionOption.A,
            "Ellipses are widely used in mathematics, astronomy, engineering, and design.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Ellipse
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Ellipse",
            "Which is the standard equation of an ellipse centered at the origin?",
            "x² + y² = r²",
            "x²/a² + y²/b² = 1",
            "y = mx + c",
            "x² = 4ay",
            QuestionOption.B,
            "The standard equation of an ellipse centered at the origin is x²/a² + y²/b² = 1.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "If a > b in the equation x²/a² + y²/b² = 1, the major axis is:",
            "Vertical",
            "Horizontal",
            "Diagonal",
            "Undefined",
            QuestionOption.B,
            "When a > b, the major axis lies along the x-axis.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "An ellipse has:",
            "One focus",
            "Two foci",
            "Three foci",
            "No focus",
            QuestionOption.B,
            "Every ellipse has two fixed points called foci.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "The major axis of an ellipse always passes through the:",
            "Radius",
            "Center",
            "Circumference",
            "Directrix",
            QuestionOption.B,
            "Both the major and minor axes pass through the center of the ellipse.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "Which statement is true for every ellipse?",
            "It is a closed curve.",
            "It has four vertices only.",
            "It always forms a circle.",
            "Its major and minor axes are always equal.",
            QuestionOption.A,
            "An ellipse is always a closed curve surrounding a region.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Ellipse
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Ellipse",
            "The orbits of many planets around the Sun are approximately:",
            "Circular",
            "Elliptical",
            "Rectangular",
            "Triangular",
            QuestionOption.B,
            "According to Kepler's First Law, planets move in elliptical orbits.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Ellipses are commonly used in:",
            "Astronomy",
            "Cooking",
            "Poetry",
            "Music theory",
            QuestionOption.A,
            "Astronomy uses ellipses to describe planetary and satellite orbits.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Architects may use elliptical shapes because they:",
            "Provide attractive and efficient designs",
            "Replace all straight lines",
            "Always require less material",
            "Can only be drawn by computers",
            QuestionOption.A,
            "Elliptical shapes are widely used in architecture for both aesthetics and structural design.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Which field commonly uses ellipses to study the motion of celestial bodies?",
            "Astronomy",
            "Biology",
            "History",
            "Chemistry",
            QuestionOption.A,
            "Astronomy uses ellipses extensively to describe orbital motion.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Why are ellipses important in mathematics and science?",
            "They model planetary motion, engineering designs, and many natural phenomena.",
            "They only help draw graphs.",
            "They replace circle equations.",
            "They are only useful in geometry classes.",
            QuestionOption.A,
            "Ellipses are fundamental in astronomy, engineering, architecture, optics, and many areas of applied mathematics.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Probability
        // ==========================================================

        AddQuestion(
            "Introduction to Probability",
            "What is probability?",
            "The study of geometric shapes",
            "A measure of how likely an event is to occur",
            "A method of solving equations",
            "The study of numbers only",
            QuestionOption.B,
            "Probability measures the chance that a particular event will happen.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Probability",
            "What is the probability of a certain event?",
            "0",
            "1",
            "0.5",
            "2",
            QuestionOption.B,
            "A certain event always occurs, so its probability is 1.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Probability",
            "What is the probability of an impossible event?",
            "0",
            "1",
            "0.5",
            "-1",
            QuestionOption.A,
            "An impossible event can never occur, so its probability is 0.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Probability",
            "The probability of any event always lies between:",
            "0 and 1",
            "1 and 10",
            "-1 and 1",
            "0 and 100",
            QuestionOption.A,
            "Probability values range from 0 (impossible) to 1 (certain).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Probability",
            "Why is probability important?",
            "It helps predict and analyze uncertain events.",
            "It only solves algebraic equations.",
            "It is only used in gambling.",
            "It replaces arithmetic.",
            QuestionOption.A,
            "Probability is widely used to make informed decisions under uncertainty.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Basic Probability Rules
        // ==========================================================

        AddQuestion(
            "Basic Probability Rules",
            "What is the probability of getting a head when tossing a fair coin?",
            "1/4",
            "1/2",
            "1",
            "2",
            QuestionOption.B,
            "A fair coin has two equally likely outcomes, so the probability of heads is 1/2.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Basic Probability Rules",
            "What is the probability of rolling a 4 on a fair six-sided die?",
            "1/4",
            "1/5",
            "1/6",
            "1/3",
            QuestionOption.C,
            "There is one favorable outcome out of six equally likely outcomes.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Basic Probability Rules",
            "If an event has probability 0.3, what is the probability that it does not occur?",
            "0.3",
            "0.5",
            "0.7",
            "1.3",
            QuestionOption.C,
            "The probability of the complement is 1 - 0.3 = 0.7.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Basic Probability Rules",
            "When two events cannot happen at the same time, they are called:",
            "Independent events",
            "Mutually exclusive events",
            "Dependent events",
            "Certain events",
            QuestionOption.B,
            "Mutually exclusive events cannot occur simultaneously.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Basic Probability Rules",
            "The sum of the probabilities of all possible outcomes of an experiment is:",
            "0",
            "1",
            "10",
            "100",
            QuestionOption.B,
            "The probabilities of all possible outcomes always add up to 1.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Probability
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Probability",
            "Weather forecasting commonly uses:",
            "Probability",
            "Geometry",
            "Calculus only",
            "Trigonometry only",
            QuestionOption.A,
            "Meteorologists use probability to predict the likelihood of weather events.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Probability",
            "Insurance companies use probability to:",
            "Assess risks",
            "Draw geometric figures",
            "Measure distances",
            "Find square roots",
            QuestionOption.A,
            "Insurance companies estimate the likelihood of events to determine premiums.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Probability",
            "Which field uses probability to analyze data and make predictions?",
            "Statistics",
            "Grammar",
            "Painting",
            "Music",
            QuestionOption.A,
            "Statistics relies heavily on probability to interpret data and predict outcomes.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Probability",
            "Probability is useful in games because it helps:",
            "Estimate the chances of different outcomes",
            "Guarantee winning",
            "Change the rules",
            "Remove uncertainty",
            QuestionOption.A,
            "Probability helps players understand the likelihood of different results but does not guarantee outcomes.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Probability",
            "Why is probability important in everyday life?",
            "It helps people make informed decisions when outcomes are uncertain.",
            "It eliminates uncertainty completely.",
            "It only applies to mathematics exams.",
            "It replaces logical reasoning.",
            QuestionOption.A,
            "Probability supports decision-making in science, medicine, finance, engineering, business, and daily life whenever uncertainty exists.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Conic Sections
        // ==========================================================

        AddQuestion(
            "Introduction to Conic Sections",
            "What are conic sections?",
            "Curves formed by the intersection of a plane and a cone",
            "Straight lines drawn on a plane",
            "Closed polygons with equal sides",
            "Three-dimensional solids",
            QuestionOption.A,
            "Conic sections are curves obtained when a plane intersects a double cone.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Conic Sections",
            "Which of the following is NOT a conic section?",
            "Circle",
            "Ellipse",
            "Rectangle",
            "Hyperbola",
            QuestionOption.C,
            "The four conic sections are circle, parabola, ellipse, and hyperbola.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Conic Sections",
            "Which conic section is formed when the plane cuts the cone parallel to its base?",
            "Parabola",
            "Circle",
            "Ellipse",
            "Hyperbola",
            QuestionOption.B,
            "A circle is formed when the cutting plane is parallel to the base of the cone.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Conic Sections",
            "How many basic conic sections are there?",
            "Two",
            "Three",
            "Four",
            "Five",
            QuestionOption.C,
            "The four basic conic sections are the circle, parabola, ellipse, and hyperbola.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Conic Sections",
            "Why are conic sections important?",
            "They help describe many natural and engineered curves.",
            "They are only useful for drawing graphs.",
            "They replace algebra completely.",
            "They are only used in geometry exams.",
            QuestionOption.A,
            "Conic sections are widely used in mathematics, engineering, astronomy, and physics.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Conic Sections
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which equation represents a circle centered at the origin?",
            "x² + y² = r²",
            "y² = 4ax",
            "x²/a² + y²/b² = 1",
            "x²/a² - y²/b² = 1",
            QuestionOption.A,
            "The equation x² + y² = r² represents a circle centered at the origin.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which conic section has exactly one focus?",
            "Circle",
            "Ellipse",
            "Parabola",
            "Hyperbola",
            QuestionOption.C,
            "A parabola has one focus and one directrix.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which conic section has two branches?",
            "Circle",
            "Parabola",
            "Ellipse",
            "Hyperbola",
            QuestionOption.D,
            "A hyperbola consists of two separate branches.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which conic section has two foci?",
            "Ellipse and Hyperbola",
            "Circle only",
            "Parabola only",
            "Circle and Parabola",
            QuestionOption.A,
            "Both ellipses and hyperbolas have two foci.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which statement is true about all conic sections?",
            "They are obtained by intersecting a plane with a cone.",
            "They are all closed curves.",
            "They all have two foci.",
            "They all have the same equation.",
            QuestionOption.A,
            "Every conic section is formed by slicing a cone with a plane at different angles.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Conic Sections
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Which field commonly uses conic sections to describe planetary motion?",
            "Astronomy",
            "History",
            "Grammar",
            "Biology",
            QuestionOption.A,
            "Planetary orbits are commonly modeled using conic sections, especially ellipses.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Satellite dishes are based primarily on which conic section?",
            "Circle",
            "Parabola",
            "Ellipse",
            "Hyperbola",
            QuestionOption.B,
            "Satellite dishes use the reflective property of parabolas to focus signals.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Which profession commonly uses conic sections when designing bridges, roads, and structures?",
            "Engineers",
            "Musicians",
            "Writers",
            "Chefs",
            QuestionOption.A,
            "Engineers use conic sections extensively in design and structural analysis.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Which technology relies on the reflective properties of parabolas?",
            "Satellite communication",
            "Word processing",
            "Spreadsheet software",
            "Text messaging",
            QuestionOption.A,
            "Parabolic reflectors are widely used in antennas, satellite dishes, and telescopes.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Why are conic sections important in mathematics and science?",
            "They model many natural phenomena and are widely used in engineering, astronomy, optics, and architecture.",
            "They are only useful for classroom exercises.",
            "They replace all other geometry concepts.",
            "They are only used to draw graphs.",
            QuestionOption.A,
            "Conic sections have numerous practical applications in science, engineering, physics, navigation, and technology.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Trigonometric Ratios
        // ==========================================================

        AddQuestion(
            "Introduction to Trigonometric Ratios",
            "What are trigonometric ratios used for?",
            "To measure probability",
            "To relate the angles and sides of a right-angled triangle",
            "To calculate the area of circles",
            "To solve quadratic equations",
            QuestionOption.B,
            "Trigonometric ratios describe the relationship between the sides and angles of a right-angled triangle.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Trigonometric Ratios",
            "Which trigonometric ratio is defined as opposite side divided by hypotenuse?",
            "Cosine",
            "Tangent",
            "Sine",
            "Cotangent",
            QuestionOption.C,
            "The sine of an angle is the ratio of the opposite side to the hypotenuse.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Trigonometric Ratios",
            "Which side of a right triangle is always the longest?",
            "Adjacent side",
            "Opposite side",
            "Hypotenuse",
            "Base",
            QuestionOption.C,
            "The hypotenuse is opposite the right angle and is always the longest side.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Trigonometric Ratios",
            "Which trigonometric ratio is equal to adjacent side divided by hypotenuse?",
            "Sine",
            "Cosine",
            "Tangent",
            "Secant",
            QuestionOption.B,
            "Cosine is defined as adjacent divided by hypotenuse.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Trigonometric Ratios",
            "Why are trigonometric ratios important?",
            "They help determine unknown sides and angles in right triangles.",
            "They are only useful for drawing graphs.",
            "They replace algebra completely.",
            "They are only used in geometry exams.",
            QuestionOption.A,
            "Trigonometric ratios are fundamental for solving problems involving right-angled triangles.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Understanding and Solving Trigonometric Ratios
        // ==========================================================

        AddQuestion(
            "Understanding and Solving Trigonometric Ratios",
            "The tangent of an angle is equal to:",
            "Opposite ÷ Hypotenuse",
            "Adjacent ÷ Hypotenuse",
            "Opposite ÷ Adjacent",
            "Hypotenuse ÷ Opposite",
            QuestionOption.C,
            "Tangent is the ratio of the opposite side to the adjacent side.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Understanding and Solving Trigonometric Ratios",
            "If the opposite side is 6 units and the hypotenuse is 10 units, what is sin θ?",
            "0.4",
            "0.5",
            "0.6",
            "0.8",
            QuestionOption.C,
            "sin θ = opposite ÷ hypotenuse = 6 ÷ 10 = 0.6.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Understanding and Solving Trigonometric Ratios",
            "If the adjacent side is 8 units and the hypotenuse is 10 units, what is cos θ?",
            "0.6",
            "0.8",
            "1.0",
            "0.2",
            QuestionOption.B,
            "cos θ = adjacent ÷ hypotenuse = 8 ÷ 10 = 0.8.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Understanding and Solving Trigonometric Ratios",
            "If the opposite side is 9 units and the adjacent side is 3 units, what is tan θ?",
            "2",
            "3",
            "4",
            "6",
            QuestionOption.B,
            "tan θ = opposite ÷ adjacent = 9 ÷ 3 = 3.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Understanding and Solving Trigonometric Ratios",
            "Which trigonometric ratio uses only the opposite and adjacent sides?",
            "Sine",
            "Cosine",
            "Tangent",
            "Secant",
            QuestionOption.C,
            "Tangent is calculated using the opposite and adjacent sides only.",
            DifficultyLevel.Advance,
            5);

        // PQ. 4

        // ==========================================================
        // Applications and Practice of Trigonometric Ratios
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Trigonometric Ratios",
            "Trigonometric ratios are commonly used to measure:",
            "Heights and distances",
            "Temperature",
            "Population",
            "Speed only",
            QuestionOption.A,
            "Trigonometry is widely used to calculate heights and distances that cannot be measured directly.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Trigonometric Ratios",
            "Which profession frequently uses trigonometry?",
            "Engineer",
            "Chef",
            "Novelist",
            "Singer",
            QuestionOption.A,
            "Engineers use trigonometry in surveying, construction, and structural design.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Trigonometric Ratios",
            "Navigation systems use trigonometric ratios to:",
            "Determine positions and distances",
            "Write documents",
            "Store files",
            "Create databases",
            QuestionOption.A,
            "Navigation relies on trigonometric calculations to determine locations and routes.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Trigonometric Ratios",
            "In physics, trigonometric ratios help analyze:",
            "Forces and motion",
            "Grammar",
            "Chemical names",
            "Literature",
            QuestionOption.A,
            "Physics uses trigonometry to resolve vectors and analyze motion.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Trigonometric Ratios",
            "Why are trigonometric ratios important in real life?",
            "They help solve practical problems involving heights, distances, engineering, navigation, and science.",
            "They are only useful for classroom exercises.",
            "They replace geometry completely.",
            "They are only used to draw triangles.",
            QuestionOption.A,
            "Trigonometric ratios are essential tools in engineering, architecture, surveying, navigation, physics, and many other real-world applications.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Trigonometric Identities
        // ==========================================================

        AddQuestion(
            "Introduction to Trigonometric Identities",
            "What is a trigonometric identity?",
            "An equation true only for specific angles",
            "An equation that is true for all values where it is defined",
            "A formula used only for right triangles",
            "An equation with no solution",
            QuestionOption.B,
            "A trigonometric identity is an equation that holds true for every value of the variable for which both sides are defined.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Trigonometric Identities",
            "Which of the following is a Pythagorean identity?",
            "sin²θ + cos²θ = 1",
            "sinθ + cosθ = 1",
            "tanθ = sinθ + cosθ",
            "secθ = sinθ/cosθ",
            QuestionOption.A,
            "The identity sin²θ + cos²θ = 1 is one of the fundamental Pythagorean identities.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Trigonometric Identities",
            "Which trigonometric function is the reciprocal of cosine?",
            "Cosecant",
            "Cotangent",
            "Secant",
            "Tangent",
            QuestionOption.C,
            "Secant (sec) is the reciprocal of cosine (cos).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Trigonometric Identities",
            "The quotient identity for tangent is:",
            "tanθ = cosθ/sinθ",
            "tanθ = sinθ/cosθ",
            "tanθ = secθ/cosecθ",
            "tanθ = sin²θ + cos²θ",
            QuestionOption.B,
            "The tangent function is defined as sinθ divided by cosθ.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Trigonometric Identities",
            "Why are trigonometric identities important?",
            "They help simplify expressions and prove mathematical relationships.",
            "They only calculate triangle areas.",
            "They replace trigonometric ratios.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Trigonometric identities simplify calculations and help prove mathematical equations.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Simplifying Expressions Using Trigonometric Identities
        // ==========================================================

        AddQuestion(
            "Simplifying Expressions Using Trigonometric Identities",
            "Using identities, sin²θ + cos²θ is equal to:",
            "0",
            "1",
            "2",
            "sinθ",
            QuestionOption.B,
            "According to the Pythagorean identity, sin²θ + cos²θ = 1.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Simplifying Expressions Using Trigonometric Identities",
            "Which identity expresses sec²θ?",
            "1 + tan²θ",
            "1 - tan²θ",
            "sin²θ + cos²θ",
            "1 + cot²θ",
            QuestionOption.A,
            "The Pythagorean identity states sec²θ = 1 + tan²θ.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Simplifying Expressions Using Trigonometric Identities",
            "Which reciprocal identity is correct?",
            "sinθ = 1/secθ",
            "cosθ = 1/cosecθ",
            "cosecθ = 1/sinθ",
            "tanθ = 1/cosθ",
            QuestionOption.C,
            "Cosecant is the reciprocal of sine.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Simplifying Expressions Using Trigonometric Identities",
            "Which identity helps express cotθ in terms of sine and cosine?",
            "cotθ = sinθ/cosθ",
            "cotθ = cosθ/sinθ",
            "cotθ = secθ/cosecθ",
            "cotθ = sin²θ",
            QuestionOption.B,
            "Cotangent is equal to cosine divided by sine.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Simplifying Expressions Using Trigonometric Identities",
            "The main purpose of trigonometric identities is to:",
            "Simplify expressions and verify equations",
            "Find the area of circles",
            "Measure probability",
            "Convert units",
            QuestionOption.A,
            "Identities make complex trigonometric expressions easier to solve and verify.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Trigonometric Identities
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Trigonometric Identities",
            "Trigonometric identities are widely used in:",
            "Physics",
            "Grammar",
            "Cooking",
            "History",
            QuestionOption.A,
            "Physics frequently uses trigonometric identities in wave and motion analysis.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Trigonometric Identities",
            "Engineers use trigonometric identities mainly to:",
            "Analyze structures and signals",
            "Write essays",
            "Design books",
            "Measure rainfall",
            QuestionOption.A,
            "Engineering applications include structural analysis, electrical signals, and mechanical design.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Trigonometric Identities",
            "Which field commonly applies trigonometric identities to study sound and light waves?",
            "Physics",
            "Literature",
            "Biology",
            "Economics",
            QuestionOption.A,
            "Wave motion in physics is commonly analyzed using trigonometric identities.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Trigonometric Identities",
            "Computer graphics use trigonometric identities to:",
            "Perform rotations and animations",
            "Store files",
            "Compress images only",
            "Manage databases",
            QuestionOption.A,
            "Trigonometric identities are essential for transformations, rotations, and animations in graphics.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Trigonometric Identities",
            "Why are trigonometric identities important in mathematics and science?",
            "They simplify complex calculations and support problem-solving in engineering, physics, and technology.",
            "They are only useful in school examinations.",
            "They replace trigonometric ratios completely.",
            "They are only used to draw graphs.",
            QuestionOption.A,
            "Trigonometric identities are fundamental tools used across mathematics, engineering, computer graphics, navigation, and physics.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Compound Angles
        // ==========================================================

        AddQuestion(
            "Introduction to Compound Angles",
            "What is a compound angle?",
            "An angle greater than 360°",
            "An angle formed by adding or subtracting two angles",
            "An angle equal to 90°",
            "An angle inside a triangle",
            QuestionOption.B,
            "A compound angle is formed by adding or subtracting two angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Compound Angles",
            "Which operation is commonly used to form a compound angle?",
            "Multiplication only",
            "Division only",
            "Addition or subtraction",
            "Square root",
            QuestionOption.C,
            "Compound angles are created by adding or subtracting two angles.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Compound Angles",
            "Which trigonometric functions have compound angle formulas?",
            "Only sine",
            "Only cosine",
            "Only tangent",
            "Sine, cosine, and tangent",
            QuestionOption.D,
            "Compound angle formulas exist for sine, cosine, and tangent.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Compound Angles",
            "The formula sin(A + B) is used to:",
            "Find the sine of the sum of two angles",
            "Find the cosine of an angle",
            "Find the tangent of an angle",
            "Calculate the area of a triangle",
            QuestionOption.A,
            "The sine addition formula calculates the sine of the sum of two angles.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Compound Angles",
            "Why are compound angle formulas important?",
            "They simplify trigonometric calculations involving sums and differences of angles.",
            "They only measure triangle areas.",
            "They replace trigonometric identities.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Compound angle formulas are essential for solving many trigonometric problems efficiently.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Problems Using Compound Angle Formulas
        // ==========================================================

        AddQuestion(
            "Solving Problems Using Compound Angle Formulas",
            "Which formula correctly represents sin(A + B)?",
            "sinA cosB + cosA sinB",
            "sinA cosB - cosA sinB",
            "cosA cosB - sinA sinB",
            "tanA + tanB",
            QuestionOption.A,
            "The sine addition formula is sin(A + B) = sinA cosB + cosA sinB.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Problems Using Compound Angle Formulas",
            "Which formula correctly represents cos(A + B)?",
            "cosA cosB + sinA sinB",
            "cosA cosB - sinA sinB",
            "sinA cosB + cosA sinB",
            "tanA tanB",
            QuestionOption.B,
            "The cosine addition formula is cos(A + B) = cosA cosB - sinA sinB.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Problems Using Compound Angle Formulas",
            "Which formula represents tan(A + B)?",
            "(tanA + tanB)/(1 - tanA tanB)",
            "(tanA - tanB)/(1 + tanA tanB)",
            "tanA + tanB",
            "sinA + cosB",
            QuestionOption.A,
            "The tangent addition formula is (tanA + tanB)/(1 - tanA tanB).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Compound Angle Formulas",
            "The formula sin(A - B) differs from sin(A + B) because:",
            "The second term changes from plus to minus",
            "The first term changes sign",
            "Both terms become negative",
            "There is no difference",
            QuestionOption.A,
            "The subtraction formula is sin(A - B) = sinA cosB - cosA sinB.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Compound Angle Formulas",
            "Compound angle formulas are mainly used to:",
            "Simplify expressions and solve trigonometric equations",
            "Find square roots",
            "Calculate probability",
            "Convert units",
            QuestionOption.A,
            "These formulas simplify complex trigonometric expressions and aid in solving equations.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Compound Angles
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Compound Angles",
            "Compound angle formulas are commonly used in:",
            "Physics",
            "Grammar",
            "Cooking",
            "History",
            QuestionOption.A,
            "Physics uses compound angle formulas to analyze waves, oscillations, and forces.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Compound Angles",
            "Engineers use compound angle formulas to:",
            "Analyze structures and signals",
            "Write essays",
            "Create paintings",
            "Measure rainfall",
            QuestionOption.A,
            "Engineering applications include structural analysis, electronics, and signal processing.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Compound Angles",
            "Which field commonly uses compound angle formulas to analyze wave motion?",
            "Physics",
            "Literature",
            "Economics",
            "Biology",
            QuestionOption.A,
            "Wave behavior is frequently analyzed using compound angle identities in physics.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Compound Angles",
            "Computer graphics use compound angle formulas for:",
            "Object rotation and animation",
            "Database management",
            "Text formatting",
            "File compression",
            QuestionOption.A,
            "Rotating objects and performing transformations rely on trigonometric formulas.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Compound Angles",
            "Why are compound angle formulas important in mathematics and engineering?",
            "They simplify advanced calculations involving angles and are widely used in science, engineering, and technology.",
            "They are only useful for examinations.",
            "They replace trigonometric identities.",
            "They are only used for drawing graphs.",
            QuestionOption.A,
            "Compound angle formulas are fundamental tools in mathematics, physics, engineering, computer graphics, and signal processing.",
            DifficultyLevel.Advance,
            5);







        context.PracticeQuestions.AddRange(questions);
        await context.SaveChangesAsync();
    }
}