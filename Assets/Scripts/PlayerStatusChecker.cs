using TMPro;
using UnityEngine;

public class PlayerStatusChecker : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private GameObject[] numberStatusText;

    private int _pointsForStatus = 0;

    public void PlusPointForStatus(int counts)
    {
        _pointsForStatus += counts;
        StatusIdentification();
    }

    public void StatusIdentification()
    {
        foreach (GameObject textGameObject in numberStatusText)
            textGameObject.SetActive(false);

        switch (_pointsForStatus) 
        {
            case 0:
                statusText.text = "�������� ������� ���� ��������!\n������, ���� ����������!";
                numberStatusText[0].SetActive(true);
                break;
            case 1:
                statusText.text = "����� ���� � �����!\n�� � ���� �� �������!";
                numberStatusText[1].SetActive(true);
                break;
            case 2:
                statusText.text = "�������, �� ��������� ��������, ��� ��� ��������!";
                numberStatusText[2].SetActive(true);
                break;
            case 3:
                statusText.text = "�� ����������� �����!\n� ������ ��������!";
                numberStatusText[3].SetActive(true);
                break;
            case 4:
                statusText.text = "���� ������ ���������� �����, ����� ������� ��������� ���������!";
                numberStatusText[4].SetActive(true);
                break;
            case 5:
                statusText.text = "��! �� ������ ���� ������� �����������!\n��� �������!";
                numberStatusText[5].SetActive(true);
                break;
            case 6:
                statusText.text = "� ������ ������� ��� �� �������!\n�������!";
                numberStatusText[6].SetActive(true);
                break;
            case 7:
                statusText.text = "� ����� �� ������� ��������� �������������� ��������!";
                numberStatusText[7].SetActive(true);
                break;
            case 8:
                statusText.text = "��� ���������� ����� �������� �������� ����� �������!\n�� ������� ������������!";
                numberStatusText[8].SetActive(true);
                break;
            case 9:
                statusText.text = "������ �� �� ������� � ������������!\n��� �������!";
                numberStatusText[9].SetActive(true);
                break;
            case 10:
                statusText.text = "������ �� ��������� ������� �� ������������ ��������!\n����������!";
                numberStatusText[10].SetActive(true);
                break;
            case 11:
                statusText.text = "����� �� �����������?\n�� ��� �� ������������!";
                numberStatusText[11].SetActive(true);
                break;
            case 12:
                statusText.text = "���� � ���� ��� ����� ��������!\n������ ���� ��������� �������!";
                numberStatusText[12].SetActive(true);
                break;
            case 13:
                statusText.text = "�������� ���!\n����� ��� ���� ���������!";
                numberStatusText[13].SetActive(true);
                break;
            case 14:
                statusText.text = "��� ������� � �� ������� ������!";
                numberStatusText[14].SetActive(true);
                break;
            case 15:
                statusText.text = "������� �� ���������������!\n�������� 3 ������!";
                numberStatusText[15].SetActive(true);
                break;
            case 16:
                statusText.text = "���� ���������� - � �������� �� ������������!\n�� ����� �� ������� ������ ����������!";
                numberStatusText[16].SetActive(true);
                break;
            case 17:
                statusText.text = "�������� ��������� ������!\n������� �� �� �������, ��� ������� �� ����� ��������!";
                numberStatusText[17].SetActive(true);
                break;
            case 18:
                statusText.text = "�����������!!!\n�� ���� �� ������ ��������!!!!";
                numberStatusText[18].SetActive(true);
                break;
            default:
                statusText.text = "������� ������� ������������!";
                break;
        }
    }
}
