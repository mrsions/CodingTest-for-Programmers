#include "pch.h"

using namespace std;

struct TestCase {
    any expect;
    vector<any> params;

    TestCase(any&& expect, vector<any>&& params)
        : expect(move(expect)), params(move(params)) {}
};

namespace n {
    vector<int> IntArr(initializer_list<int> a) { return vector<int>(a); }
    vector<int> BA(initializer_list<int> a) { return vector<int>(a); }
    template <typename T>
    vector<T> Arr(initializer_list<T> a) { return vector<T>(a); }
}

class Test {
public:
    template<typename Func>
    static void Run(Func func, const vector<TestCase>& testCases) {
        cout << "-------------------------------------------------------\n";
        cout << "Run  : Test Execution\n";
        cout << "Case : " << testCases.size() << "\n";

        bool success = true;
        for (size_t i = 0; i < testCases.size(); ++i) {
            const TestCase& testCase = testCases[i];
            try {
                auto& paramsRef = testCase.params;
                auto result = any(func(paramsRef));

                if (AnyEquals(result, testCase.expect)) {
                    cout << "[" << (i + 1) << "/" << testCases.size() << "] Success\n";
                }
                else {
                    success = false;
                    cout << "[" << (i + 1) << "/" << testCases.size() << "] Failed  (result: "
                        << GetString(result) << " != expect: " << GetString(testCase.expect) << ")\n";
                }
            }
            catch (const exception& ex) {
                cerr << "Error: " << ex.what() << "\n";
                exit(1);
                return;
            }
        }

        if (!success) {
            cout << "\nPlease press any key...";
            cin.get();
            exit(1);
        }

        Benchmark(func, testCases);
    }

private:
    template<typename Func>
    static void Benchmark(Func func, const vector<TestCase>& testCases) {
        using namespace chrono;

        auto start = high_resolution_clock::now();
        long long elapsed = 0;
        size_t cnt = 0;
        long long end = static_cast<long long>(5 * 1e6); // Approx 5 seconds worth of ticks
        while (elapsed < end) {
            for (const auto& testCase : testCases) {
                func(testCase.params);
            }
            cnt++;
            elapsed = duration_cast<microseconds>(high_resolution_clock::now() - start).count();
        }

        double ticks = static_cast<double>(elapsed) * 10.0;
        cout << format("Simple Benchmark {} / {} = {} cpt", cnt, (ticks / 1e7), ticks / cnt) << endl;
    }

    static string GetString(const any& result) {
        if (!result.has_value()) return "null";
        try {
            if (result.type() == typeid(int)) {
                return to_string(any_cast<int>(result));
            }
            else if (result.type() == typeid(double)) {
                return to_string(any_cast<double>(result));
            }
            else if (result.type() == typeid(string)) {
                return any_cast<string>(result);
            }
            else if (result.type() == typeid(vector<int>)) {
                const auto& vec = any_cast<vector<int>>(result);
                string res = "{";
                for (size_t i = 0; i < vec.size(); ++i) {
                    res += to_string(vec[i]);
                    if (i < vec.size() - 1) res += ", ";
                }
                res += "}";
                return res;
            }
            // Add more type conversions as needed
        }
        catch (const bad_any_cast&) {
            return "(unknown)";
        }
        return "(unsupported type)";
    }

    static bool AnyEquals(const any& a, const any& b) {
        if (!a.has_value() && !b.has_value()) return true;
        if (!a.has_value() || !b.has_value()) return false;
        if (a.type() != b.type()) return false;

        try {
            if (a.type() == typeid(int)) {
                return any_cast<int>(a) == any_cast<int>(b);
            }
            else if (a.type() == typeid(double)) {
                return any_cast<double>(a) == any_cast<double>(b);
            }
            else if (a.type() == typeid(string)) {
                return any_cast<string>(a) == any_cast<string>(b);
            }
            else if (a.type() == typeid(vector<int>)) {
                return any_cast<vector<int>>(a) == any_cast<vector<int>>(b);
            }
            // Add more type comparisons as needed
        }
        catch (const bad_any_cast&) {
            return false;
        }
        return false;
    }

public:
    static vector<string> GetReadStringVector(string path)
    {
        std::vector<std::string> commands;
        std::ifstream inputFile("commands.txt");
        if (inputFile.is_open()) {
            std::string line;
            while (std::getline(inputFile, line)) {
                commands.push_back(line);
            }
            inputFile.close();
        }
        else {
            std::cerr << "Unable to open file command.txt" << std::endl;
            throw 0;
        }
        return commands;
    }
};
