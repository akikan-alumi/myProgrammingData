using UnityEngine;
using System.Collections;

public class LinkType<T> : MonoBehaviour where T : LinkType<T> {
	public string moji ="Kyouyuu";//必要なだけ変数を作ってOK。内部クラスを作っても良い
	
	protected static T instance;
	public static T Instance {
		get {
			if (instance == null) {
				instance = (T)FindObjectOfType (typeof(T));
				
				if (instance == null) {
					Debug.LogWarning (typeof(T) + "インスタンス無いよ");
				}
			}
			
			return instance;
		}
	}
	
	protected bool CheckInstance()
	{
		if( instance == null)
		{
			instance = (T)this;
			return true;
		}else if( Instance == this )
		{
			return true;
		}
		
		Destroy(this);
		return false;
	}
	
	protected void Awake()
	{
		CheckInstance();
	}

}
