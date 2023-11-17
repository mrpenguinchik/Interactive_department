using UnityEngine;

[CreateAssetMenu(fileName = nameof(Money), menuName = "Resources/Money", order = 51)]
public class Money : Resource
{
    [SerializeField] private string _key = "SET_SAVE_NAME";
    [SerializeField] private Sprite _icon;

    public override Data.Key Key => new Data.Key(_key);
    public override Sprite Sprite => _icon;
}
