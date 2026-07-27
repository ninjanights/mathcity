using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class StatisticsLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {

      // ==========================================================
// Data Collection
// ==========================================================

new Lesson
{
    TopicId = topics["Data Collection"].Id,
    Title = "Introduction to Data Collection",
    Slug = "introduction-to-data-collection",
    Summary = "Learn the fundamentals of data collection, understand different types of data, sources of information, and how data is gathered for statistical analysis.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Data Collection"].Id,
    Title = "Methods and Techniques of Data Collection",
    Slug = "methods-and-techniques-of-data-collection",
    Summary = "Explore primary and secondary data collection methods, sampling techniques, surveys, experiments, and approaches used to collect reliable statistical data.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Data Collection"].Id,
    Title = "Applications and Practice of Data Collection",
    Slug = "applications-and-practice-of-data-collection",
    Summary = "Apply data collection concepts to solve statistical problems and explore applications in business, healthcare, research, artificial intelligence, machine learning, and data science.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Measures of Central Tendency
// ==========================================================

new Lesson
{
    TopicId = topics["Measures of Central Tendency"].Id,
    Title = "Introduction to Measures of Central Tendency",
    Slug = "introduction-to-measures-of-central-tendency",
    Summary = "Learn the fundamentals of central tendency, including mean, median, and mode, and understand how they represent the central value of a dataset.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Measures of Central Tendency"].Id,
    Title = "Calculating Mean, Median, and Mode",
    Slug = "calculating-mean-median-and-mode",
    Summary = "Explore methods for calculating arithmetic mean, median, and mode, compare their properties, and solve statistical problems using different datasets.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Measures of Central Tendency"].Id,
    Title = "Applications and Practice of Central Tendency",
    Slug = "applications-and-practice-of-central-tendency",
    Summary = "Apply measures of central tendency to analyze real-world data and explore applications in business, economics, healthcare, sports analytics, research, and data science.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Measures of Dispersion
// ==========================================================

new Lesson
{
    TopicId = topics["Measures of Dispersion"].Id,
    Title = "Introduction to Measures of Dispersion",
    Slug = "introduction-to-measures-of-dispersion",
    Summary = "Learn the fundamentals of dispersion, understand how data variability is measured, and explore concepts such as range, variance, and standard deviation.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Measures of Dispersion"].Id,
    Title = "Calculating Variance and Standard Deviation",
    Slug = "calculating-variance-and-standard-deviation",
    Summary = "Explore methods for calculating range, variance, standard deviation, and other measures of dispersion to analyze the spread of datasets.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Measures of Dispersion"].Id,
    Title = "Applications and Practice of Measures of Dispersion",
    Slug = "applications-and-practice-of-measures-of-dispersion",
    Summary = "Apply dispersion concepts to analyze real-world datasets and explore applications in finance, economics, research, quality control, machine learning, and data science.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Frequency Distribution
// ==========================================================

new Lesson
{
    TopicId = topics["Frequency Distribution"].Id,
    Title = "Introduction to Frequency Distribution",
    Slug = "introduction-to-frequency-distribution",
    Summary = "Learn the fundamentals of frequency distribution, understand how data is organized into groups, and explore how frequencies help summarize large datasets.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Frequency Distribution"].Id,
    Title = "Creating and Analyzing Frequency Distributions",
    Slug = "creating-and-analyzing-frequency-distributions",
    Summary = "Explore frequency tables, class intervals, cumulative frequency, relative frequency, and methods to analyze grouped and ungrouped statistical data.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Frequency Distribution"].Id,
    Title = "Applications and Practice of Frequency Distribution",
    Slug = "applications-and-practice-of-frequency-distribution",
    Summary = "Apply frequency distribution concepts to organize and interpret real-world datasets and explore applications in research, business analytics, economics, healthcare, and data science.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},
// ==========================================================
// Histograms
// ==========================================================

new Lesson
{
    TopicId = topics["Histograms"].Id,
    Title = "Introduction to Histograms",
    Slug = "introduction-to-histograms",
    Summary = "Learn the fundamentals of histograms, understand how continuous data is represented visually, and explore how frequency distributions are displayed using bars.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Histograms"].Id,
    Title = "Creating and Interpreting Histograms",
    Slug = "creating-and-interpreting-histograms",
    Summary = "Explore how to construct histograms, choose class intervals, analyze data patterns, and interpret distribution shapes such as symmetry, skewness, and spread.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Histograms"].Id,
    Title = "Applications and Practice of Histograms",
    Slug = "applications-and-practice-of-histograms",
    Summary = "Apply histogram concepts to analyze real-world datasets and explore applications in data analysis, research, business intelligence, machine learning, quality control, and statistics.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Box Plots
// ==========================================================

new Lesson
{
    TopicId = topics["Box Plots"].Id,
    Title = "Introduction to Box Plots",
    Slug = "introduction-to-box-plots",
    Summary = "Learn the fundamentals of box plots, understand quartiles, median, minimum, maximum values, and how box plots represent the distribution of data.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Box Plots"].Id,
    Title = "Creating and Interpreting Box Plots",
    Slug = "creating-and-interpreting-box-plots",
    Summary = "Explore how to construct box plots using five-number summaries, analyze interquartile range, identify outliers, and compare different datasets.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Box Plots"].Id,
    Title = "Applications and Practice of Box Plots",
    Slug = "applications-and-practice-of-box-plots",
    Summary = "Apply box plot concepts to analyze real-world datasets and explore applications in statistics, research, business analytics, healthcare, finance, and data science.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Correlation
// ==========================================================

new Lesson
{
    TopicId = topics["Correlation"].Id,
    Title = "Introduction to Correlation",
    Slug = "introduction-to-correlation",
    Summary = "Learn the fundamentals of correlation, understand relationships between variables, and explore how correlation measures the strength and direction of association between datasets.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Correlation"].Id,
    Title = "Calculating and Interpreting Correlation",
    Slug = "calculating-and-interpreting-correlation",
    Summary = "Explore correlation coefficients, positive and negative relationships, scatter plots, and methods to analyze the relationship between two variables.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Correlation"].Id,
    Title = "Applications and Practice of Correlation",
    Slug = "applications-and-practice-of-correlation",
    Summary = "Apply correlation concepts to analyze real-world relationships and explore applications in data science, machine learning, economics, healthcare, business analytics, and scientific research.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Regression
// ==========================================================

new Lesson
{
    TopicId = topics["Regression"].Id,
    Title = "Introduction to Regression",
    Slug = "introduction-to-regression",
    Summary = "Learn the fundamentals of regression, understand how relationships between variables are modeled, and explore how regression helps predict future outcomes.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Regression"].Id,
    Title = "Linear Regression and Prediction Models",
    Slug = "linear-regression-and-prediction-models",
    Summary = "Explore linear regression equations, lines of best fit, residuals, regression coefficients, and methods for making predictions from datasets.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Regression"].Id,
    Title = "Applications and Practice of Regression",
    Slug = "applications-and-practice-of-regression",
    Summary = "Apply regression concepts to solve advanced statistical problems and explore applications in machine learning, artificial intelligence, economics, finance, healthcare, and data science.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Sampling
// ==========================================================

new Lesson
{
    TopicId = topics["Sampling"].Id,
    Title = "Introduction to Sampling",
    Slug = "introduction-to-sampling",
    Summary = "Learn the fundamentals of sampling, understand populations and samples, and explore why sampling is used to study large groups of data efficiently.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Sampling"].Id,
    Title = "Sampling Methods and Techniques",
    Slug = "sampling-methods-and-techniques",
    Summary = "Explore different sampling methods including random sampling, stratified sampling, systematic sampling, and cluster sampling, and understand their applications in statistical analysis.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Sampling"].Id,
    Title = "Applications and Practice of Sampling",
    Slug = "applications-and-practice-of-sampling",
    Summary = "Apply sampling concepts to solve statistical problems and explore applications in surveys, research, business analytics, healthcare, artificial intelligence, machine learning, and data science.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Hypothesis Testing
// ==========================================================

new Lesson
{
    TopicId = topics["Hypothesis Testing"].Id,
    Title = "Introduction to Hypothesis Testing",
    Slug = "introduction-to-hypothesis-testing",
    Summary = "Learn the fundamentals of hypothesis testing, understand null and alternative hypotheses, and explore how statistical decisions are made using sample data.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Hypothesis Testing"].Id,
    Title = "Statistical Tests and Significance Levels",
    Slug = "statistical-tests-and-significance-levels",
    Summary = "Explore p-values, confidence levels, test statistics, critical regions, and common hypothesis tests used to analyze and interpret data.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Hypothesis Testing"].Id,
    Title = "Applications and Practice of Hypothesis Testing",
    Slug = "applications-and-practice-of-hypothesis-testing",
    Summary = "Apply hypothesis testing concepts to solve advanced statistical problems and explore applications in research, healthcare, finance, business analytics, machine learning, and data science.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},

        };

        await context.Lessons.AddRangeAsync(lessons);
        await context.SaveChangesAsync();
    }
}