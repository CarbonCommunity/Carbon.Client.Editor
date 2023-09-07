/*
 *
 * Copyright (c) 2022-2023 Carbon Community 
 * All rights reserved.
 *
 */

namespace Carbon.Client.Assets
{
	public interface IStore<T, TA>
	{
		byte[] Store();
	}
}
