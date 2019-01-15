#include "stdafx.h"
#include "CppUnitTest.h"
#include "../QuickSubway/subway.h"
#include "../QuickSubway/input.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest1
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		Subway subway;

		TEST_METHOD(TestLineRight_1)
		{
			string line = "房山线";
			string ans[15] = { "阎村东", "苏庄", "良乡南关", "良乡大学城西", "良乡大学城", "良乡大学城北", "广阳城", "篱笆房", "长阳", "稻田", "大葆台", "郭公庄" };
			subway.GetLine(line);
			for (int i = 0; i < 12; i++) {
				cout << unit_test[i] << " " << ans[i] << endl;
				Assert::AreEqual(unit_test[i], ans[i]);
			}
		}

		TEST_METHOD(TestLineWrong_2)
		{
			string line = "3号线";
			string ans = "未找到该线路";
			subway.GetLine(line);
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestDijkRight_3)
		{
			int argc = 2;
			char *argv[] = {"QuickSubway.exe", "/b", "良乡大学城北", "魏公村" };
			Input(argc, argv);
			string ans = "良乡大学城北\n广阳城\n篱笆房\n长阳\n稻田\n大葆台\n郭公庄 换乘9号线\n丰台科技园\n科怡路\n丰台南路\n丰台东大街\n七里庄\n六里桥\n六里桥东\n北京西站\n军事博物馆\n白堆子\n白石桥南\n国家图书馆 换乘4号线\n魏公村\n";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestDijkWrong_4)
		{
			int argc = 2;
			char *argv[] = {"QuickSubway.exe", "/b", "良乡大学城北", "魏村" };
			Input(argc, argv);
			string ans = "未找到对应站名";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestDijkExchange_5)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/c", "良乡大学城北", "魏公村" };
			Input(argc, argv);
			string ans = "26";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestAllNodeWrong_6)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/a", "知路"};
			Input(argc, argv);
			string ans = "未找到对应站名";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestAllNodeEx_7)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/d", "知春路" };
			Input(argc, argv);
			string ans = "763";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestAllNode_8)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/a", "知春路" };
			Input(argc, argv);
			string ans = "550";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestRight_9)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/z", "all_node_visit_true.txt" };
			Input(argc, argv);
			string ans = "true";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestWrong_10)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/z", "all_node_visit_order.txt" };
			Input(argc, argv);
			string ans = "error: 五棵松 八宝山";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestWrong_11)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/z", "all_node_visit_number.txt" };
			Input(argc, argv);
			string ans = "false";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestWrong_12)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/z", "all_node_visit_sted.txt" };
			Input(argc, argv);
			string ans = "false";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestWrong_13)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/z", "all_node_visit_leak.txt" };
			Input(argc, argv);
			string ans = "土桥";
			Assert::AreEqual(unit_test[0], ans);
		}
	};
}