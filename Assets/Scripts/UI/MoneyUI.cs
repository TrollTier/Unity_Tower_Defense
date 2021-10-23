using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField]
        private PlayerMoney playerMoney;

        [SerializeField]
        private Text currentMoneyText;

        private bool updateUI = true;

        private void Start()
        {
            playerMoney.OnAmountChanged += HandleAmountChanged;
        }

        private void OnDestroy()
        {
            playerMoney.OnAmountChanged -= HandleAmountChanged;
        }

        private void HandleAmountChanged(PlayerMoney money)
        {
            updateUI = true;
        }

        private void Update()
        {
            if (!updateUI)
            {
                return;
            }

            currentMoneyText.text = playerMoney.CurrentMoney.ToString();

            updateUI = false;
        }
    }
}
