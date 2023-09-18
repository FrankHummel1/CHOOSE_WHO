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
                statusText.text = "Попробуй угадать пару животных!\nСмелее, тебе понравится!";
                numberStatusText[0].SetActive(true);
                break;
            case 1:
                statusText.text = "Можно было и лучше!\nНо у тебя всё впереди!";
                numberStatusText[1].SetActive(true);
                break;
            case 2:
                statusText.text = "Кажется, ты начинаешь понимать, как это работает!";
                numberStatusText[2].SetActive(true);
                break;
            case 3:
                statusText.text = "Ты становишься лучше!\nС каждой попыткой!";
                numberStatusText[3].SetActive(true);
                break;
            case 4:
                statusText.text = "Если будешь продолжать также, скоро станешь настоящим экспертом!";
                numberStatusText[4].SetActive(true);
                break;
            case 5:
                statusText.text = "Хо! Да передо мной будущий профессинал!\nТак держать!";
                numberStatusText[5].SetActive(true);
                break;
            case 6:
                statusText.text = "А теперь вспомни как ты начинал!\nМолодец!";
                numberStatusText[6].SetActive(true);
                break;
            case 7:
                statusText.text = "И скоро ты станешь настоящим разгадывателем животных!";
                numberStatusText[7].SetActive(true);
                break;
            case 8:
                statusText.text = "Эту статистику можно запросто показать своим друзьям!\nТы отлично справляешься!";
                numberStatusText[8].SetActive(true);
                break;
            case 9:
                statusText.text = "Теперь ты на полпути к совершенству!\nТак держать!";
                numberStatusText[9].SetActive(true);
                break;
            case 10:
                statusText.text = "Теперь ты настоящий эксперт по разгадыванию животных!\nПоздравляю!";
                numberStatusText[10].SetActive(true);
                break;
            case 11:
                statusText.text = "Никак не успокоишься?\nДа это же замечательно!";
                numberStatusText[11].SetActive(true);
                break;
            case 12:
                statusText.text = "Даже у меня нет таких познаний!\nПередо мной настоящий эксперт!";
                numberStatusText[12].SetActive(true);
                break;
            case 13:
                statusText.text = "Несмешно уже!\nСкоро так всех отгадаешь!";
                numberStatusText[13].SetActive(true);
                break;
            case 14:
                statusText.text = "Ещё немного и ты станешь лучшим!";
                numberStatusText[14].SetActive(true);
                break;
            case 15:
                statusText.text = "Главное не останавливаться!\nОсталось 3 звезды!";
                numberStatusText[15].SetActive(true);
                break;
            case 16:
                statusText.text = "Если справишься - я расскажу всё разработчику!\nОн точно не ожидает такого результата!";
                numberStatusText[16].SetActive(true);
                break;
            case 17:
                statusText.text = "Осталась последняя звезда!\nНикогда бы не подумал, что человек на такое способен!";
                numberStatusText[17].SetActive(true);
                break;
            case 18:
                statusText.text = "ПОЗДРАВЛЯЕМ!!!\nВЫ ГУРУ ПО ЗНАНИЮ ЖИВОТНЫХ!!!!";
                numberStatusText[18].SetActive(true);
                break;
            default:
                statusText.text = "Давайте немного поотгадываем!";
                break;
        }
    }
}
