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
			string line = "��ɽ��";
			string ans[15] = { "�ִ嶫", "��ׯ", "�����Ϲ�", "�����ѧ����", "�����ѧ��", "�����ѧ�Ǳ�", "������", "��ʷ�", "����", "����", "����̨", "����ׯ" };
			subway.GetLine(line);
			for (int i = 0; i < 12; i++) {
				cout << unit_test[i] << " " << ans[i] << endl;
				Assert::AreEqual(unit_test[i], ans[i]);
			}
		}

		TEST_METHOD(TestLineWrong_2)
		{
			string line = "3����";
			string ans = "δ�ҵ�����·";
			subway.GetLine(line);
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestDijkRight_3)
		{
			int argc = 2;
			char *argv[] = {"QuickSubway.exe", "/b", "�����ѧ�Ǳ�", "κ����" };
			Input(argc, argv);
			string ans = "�����ѧ�Ǳ�\n������\n��ʷ�\n����\n����\n����̨\n����ׯ ����9����\n��̨�Ƽ�԰\n����·\n��̨��·\n��̨�����\n����ׯ\n������\n�����Ŷ�\n������վ\n���²����\n�׶���\n��ʯ����\n����ͼ��� ����4����\nκ����\n";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestDijkWrong_4)
		{
			int argc = 2;
			char *argv[] = {"QuickSubway.exe", "/b", "�����ѧ�Ǳ�", "κ��" };
			Input(argc, argv);
			string ans = "δ�ҵ���Ӧվ��";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestDijkExchange_5)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/c", "�����ѧ�Ǳ�", "κ����" };
			Input(argc, argv);
			string ans = "26";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestAllNodeWrong_6)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/a", "֪·"};
			Input(argc, argv);
			string ans = "δ�ҵ���Ӧվ��";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestAllNodeEx_7)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/d", "֪��·" };
			Input(argc, argv);
			string ans = "763";
			Assert::AreEqual(unit_test[0], ans);
		}

		TEST_METHOD(TestAllNode_8)
		{
			int argc = 2;
			char *argv[] = { "QuickSubway.exe", "/a", "֪��·" };
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
			string ans = "error: ����� �˱�ɽ";
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
			string ans = "����";
			Assert::AreEqual(unit_test[0], ans);
		}
	};
}